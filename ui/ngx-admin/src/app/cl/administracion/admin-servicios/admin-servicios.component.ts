import { NavegarServicioComponent } from './../components/navegar-servicio/navegar-servicio.component';
import { DialogoServicioComponent } from './../components/dialogo-servicio/dialogo-servicio.component';
import { CategoriasService, EmptyId } from './../servicios/categorias.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppLogService } from 'app/services/app-log-service';
import { LocalDataSource } from 'ng2-smart-table';
import { NbDialogService } from '@nebular/theme';
import { first } from 'rxjs/operators';
import { Servicio } from '../modelos/servicio';
import { ConfirmarEliminarComponent } from '../components/confirmar-eliminar/confirmar-eliminar.component';

@Component({
  selector: 'ngx-admin-servicios',
  templateUrl: './admin-servicios.component.html',
  styleUrls: ['./admin-servicios.component.scss']
})
export class AdminServiciosComponent implements OnInit {
  source: LocalDataSource = new LocalDataSource();
  loading: boolean;

  private categoriaId: string; 

  settings = {
    mode: 'external',
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    actions: {
      columnTitle: "Acciones",
    },
    columns: {
      clave: {
        title: 'Clave',
        type: 'string',
      },
      nombre: {
        title: 'Nombre', 
        type: 'string',

      }, 
      id: {
        title: 'Enlaces',
        type: 'custom',
        sort: false,
        filter: false,
        renderComponent: NavegarServicioComponent
      },
      categoriaId: {
        title: 'Id categoria',
        type: 'custom',
        sort: false,
        filter: false,
        hide: true,
      },
    },
  };

  constructor( private route: ActivatedRoute,
    private log: AppLogService,
    private apiCategoria: CategoriasService,
    private dialogService: NbDialogService) { }


  ngOnInit(): void {
    this.route.params.pipe(first()).subscribe(params => {
      this.categoriaId = params.categoriaId;
      this.loading = true;
      this.apiCategoria.GetServicios(this.categoriaId).subscribe(data => {
        this.source.load(data);
      },
        (err) => { this.log.Falla('', 'Error al obtener servicios:' + err) },
        () => { this.loading = false; })
    });
  }

  edit(event) {
    const servicioActual: Servicio = event.data;

    this.dialogService.open(DialogoServicioComponent, {
      context: {
        title: 'Actualizar servicio',
        servicio: servicioActual
      },
    }).onClose.subscribe(servicio => {
      
      if (servicio != null) {
        this.loading = true;
        this.apiCategoria.PutServicio(servicioActual.id, servicio).
          subscribe(
            (ok) => {
              console.log(servicio);
              this.source.update(servicioActual, servicio);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el servicio') },
            () => { this.loading = false; })
      }
    });;
  }

  create() {
    this.dialogService.open(DialogoServicioComponent, {
      context: {
        title: 'Crear servicio',
        servicio: { id: EmptyId, categoriaId: this.categoriaId, nombre: '', clave:'' }
      },
    }).onClose.subscribe(servicio => {
      if (servicio != null) {
        this.loading = true;
        this.apiCategoria.PostServicio(servicio).
          subscribe(
            (ok) => {
              servicio.id = ok;
              this.source.add(servicio);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el servicio') },
            () => { this.loading = false; })
      }
    });
  }

  delete(event) {

    this.dialogService.open(ConfirmarEliminarComponent, {
      context: {
        nombre: event.data.nombre,
      },
    }).onClose.subscribe(eliminar => {
      console.log(eliminar);
      if (eliminar) {
        this.loading = true;
        this.apiCategoria.DelServicio(event.data.id).
          subscribe(
            (ok) => {
              this.source.remove(event.data);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el servicio') },
            () => { this.loading = false; })
      }

    });
  }

  ManejarErrorHttp(err: any, tipo: string) {
    this.loading = false;
    switch (parseInt(err.status)) {
      case 400:
        this.log.Advertencia('', `Los datos para ${tipo} no son correctos`);
        break;

      case 500:
        this.log.Falla('', `Error de proceso para ${tipo}, consulte con el administrador`);
        break;

      case 404:
        this.log.Falla('', `Error de proceso para ${tipo}, consulte con el administrador`);
        break;

      default:
        break;
    }
  }

}

import { DialogoPrecioComponent } from './../components/dialogo-precio/dialogo-precio.component';
import { Precio } from './../modelos/precio';
import { CategoriasService, EmptyId } from './../servicios/categorias.service';
import { Component, OnInit } from '@angular/core';
import { LocalDataSource } from 'ng2-smart-table';
import { ActivatedRoute } from '@angular/router';
import { NbDialogService } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';
import { first } from 'rxjs/operators';
import { ConfirmarEliminarComponent } from '../components/confirmar-eliminar/confirmar-eliminar.component';

@Component({
  selector: 'ngx-admin-precios',
  templateUrl: './admin-precios.component.html',
  styleUrls: ['./admin-precios.component.scss']
})
export class AdminPreciosComponent implements OnInit {
  source: LocalDataSource = new LocalDataSource();
  loading: boolean;
  private servicioId: string;

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
      descripcion: {
        title: 'Descripción',
        type: 'string',
      },
      monto:{
        title:'Monto', 
        type:'Number'
      },
      id: {
        title: 'Id',
        type: 'custom',
        sort: false,
        filter: false,
        hide: true,
      },
      servicioId: {
        title: 'Id servicio',
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
      
      this.servicioId = params.servicioId;
      this.loading = true;
      this.apiCategoria.GetPrecios(this.servicioId).subscribe(data => {
        this.source.load(data);
      },
        (err) => { this.log.Falla('', 'Error al obtener precios:' + err) },
        () => { this.loading = false; })
    });
  }

  edit(event) {
    const precioActual: Precio = event.data;
    console.log(precioActual);
    this.dialogService.open(DialogoPrecioComponent, {
      context: {
        title: 'Actualizar precio',
        precio: precioActual
      },
    }).onClose.subscribe(precio => {
      console.log(precio);
      if (precio != null) {
        this.loading = true;
        this.apiCategoria.PutPrecio(precioActual.id, precio).
          subscribe(
            (ok) => {
              console.log(precio);
              this.source.update(precioActual, precio);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el precio') },
            () => { this.loading = false; })
      }
    });;
  }

  create() {
    this.dialogService.open(DialogoPrecioComponent, {
      context: {
        title: 'Crear precio',
        precio: { id: EmptyId, servicioId: this.servicioId, descripcion: '', monto:0, moneda:0, esDefault:false }
      },
    }).onClose.subscribe(precio => {
      if (precio != null) {
        this.loading = true;
        this.apiCategoria.PostPrecio(precio).
          subscribe(
            (ok) => {
              precio.id = ok;
              this.source.add(precio);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el precio') },
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
        this.apiCategoria.DelPrecio(event.data.id).
          subscribe(
            (ok) => {
              this.source.remove(event.data);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el precio') },
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

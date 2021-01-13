import { DialogoChoferComponent } from './../components/dialogo-chofer/dialogo-chofer.component';
import { Chofer } from './../modelos/chofer';
import { Component, OnInit } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';
import { LocalDataSource } from 'ng2-smart-table';
import { EmpresasService, EmptyId } from '../servicios/empresas.service';
import { ConfirmarEliminarComponent } from '../components/confirmar-eliminar/confirmar-eliminar.component';
import { ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';

@Component({
  selector: 'ngx-admin-choferes',
  templateUrl: './admin-choferes.component.html',
  styleUrls: ['./admin-choferes.component.scss']
})
export class AdminChoferesComponent implements OnInit {
  source: LocalDataSource = new LocalDataSource();
  loading: boolean;
  private empresaId: string;

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
      nombre: {
        title: 'Nombre',
        type: 'string',
      },
      id: {
        title: 'Id',
        type: 'custom',
        sort: false,
        filter: false,
        hide: true,
      },
      empresaId: {
        title: 'Id empresa',
        type: 'custom',
        sort: false,
        filter: false,
        hide: true,
      },
    },
  };

  constructor(
    private route: ActivatedRoute,
    private log: AppLogService,
    private apiEmpresas: EmpresasService,
    private dialogService: NbDialogService) { }

  ngOnInit(): void {

    this.route.params.pipe(first()).subscribe(params => {
      this.empresaId = params.empresaId;
      this.loading = true;
      this.apiEmpresas.GetChoferes(this.empresaId).subscribe(data => {
        this.source.load(data);
      },
        (err) => { this.log.Falla('', 'Error al obtener empresas:' + err) },
        () => { this.loading = false; })
    });

  }

  edit(event) {
    const choferActual: Chofer = event.data;
    console.log(choferActual);
    this.dialogService.open(DialogoChoferComponent, {
      context: {
        title: 'Actualizar chofer',
        chofer: choferActual
      },
    }).onClose.subscribe(chofer => {
      console.log(chofer);
      if (chofer != null) {
        this.loading = true;
        this.apiEmpresas.PutChofer(choferActual.id, chofer).
          subscribe(
            (ok) => {
              console.log(chofer);
              this.source.update(choferActual, chofer);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el Chofer') },
            () => { this.loading = false; })
      }
    });;
  }

  create() {
    this.dialogService.open(DialogoChoferComponent, {
      context: {
        title: 'Crear chofer',
        chofer: { id: EmptyId, empresaId: this.empresaId, nombre: '' }
      },
    }).onClose.subscribe(chofer => {
      if (chofer != null) {
        this.loading = true;
        this.apiEmpresas.PostChofer(chofer).
          subscribe(
            (ok) => {
              chofer.id = ok;
              this.source.add(chofer);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el Chofer') },
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
        this.apiEmpresas.DelChofer(event.data.id).
          subscribe(
            (ok) => {
              this.source.remove(event.data);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el Chofer') },
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

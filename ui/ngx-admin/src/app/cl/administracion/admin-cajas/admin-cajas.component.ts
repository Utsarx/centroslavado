import { DialogoCajaComponent } from './../components/dialogo-caja/dialogo-caja.component';
import { AppLogService } from './../../../services/app-log-service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LocalDataSource } from 'ng2-smart-table';
import { NbDialogService } from '@nebular/theme';
import { first } from 'rxjs/operators';
import { ConfirmarEliminarComponent } from '../components/confirmar-eliminar/confirmar-eliminar.component';
import { EmpresasService, EmptyId } from '../servicios/empresas.service';
import { Caja } from '../modelos/caja';

@Component({
  selector: 'ngx-admin-cajas',
  templateUrl: './admin-cajas.component.html',
  styleUrls: ['./admin-cajas.component.scss']
})
export class AdminCajasComponent implements  OnInit {
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
      noEconomico: {
        title: 'No. económico',
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
      this.apiEmpresas.GetCajas(this.empresaId).subscribe(data=>{ 
        this.source.load(data);
      },
        (err) => { this.log.Falla('', 'Error al obtener cajas:' + err) },
        () => { this.loading = false; })
    });

  }

  edit(event) {
    const CajaActual: Caja = event.data;

    this.dialogService.open(DialogoCajaComponent, {
      context: {
        title: 'Actualizar Caja',
        Caja: CajaActual
      },
    }).onClose.subscribe(Caja => {
      
      if (Caja != null) {
        this.loading = true;
        this.apiEmpresas.PutCaja(CajaActual.id, Caja).
          subscribe(
            (ok) => {
              console.log(Caja);
              this.source.update(CajaActual, Caja);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'la caja') },
            () => { this.loading = false; })
      }
    });;
  }

  create() {
    console.log("alfo");
    this.dialogService.open(DialogoCajaComponent, {
      context: {
        title: 'Crear Caja',
        Caja: { id: EmptyId, empresaId: this.empresaId, noEconomico: '' }
      },
    }).onClose.subscribe(Caja => {
      if (Caja != null) {
        console.log(Caja);
        this.loading = true;
        this.apiEmpresas.PostCaja(Caja).
          subscribe(
            (ok) => {
              Caja.id = ok;
              this.source.add(Caja);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el Caja') },
            () => { this.loading = false; })
      }
    });
  }

  delete(event) {

    this.dialogService.open(ConfirmarEliminarComponent, {
      context: {
        nombre: event.data.noeconomico,
      },
    }).onClose.subscribe(eliminar => {
      console.log(eliminar);
      if (eliminar) {
        this.loading = true;
        this.apiEmpresas.DelCaja(event.data.id).
          subscribe(
            (ok) => {
              this.source.remove(event.data);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'la Caja') },
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

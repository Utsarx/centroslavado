import { DialogoTractorComponent } from './../components/dialogo-tractor/dialogo-tractor.component';
import { Tractor } from './../modelos/tractor';
import { AppLogService } from './../../../services/app-log-service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LocalDataSource } from 'ng2-smart-table';
import { NbDialogService } from '@nebular/theme';
import { first } from 'rxjs/operators';
import { ConfirmarEliminarComponent } from '../components/confirmar-eliminar/confirmar-eliminar.component';
import { EmpresasService, EmptyId } from '../servicios/empresas.service';

@Component({
  selector: 'ngx-admin-tractores',
  templateUrl: './admin-tractores.component.html',
  styleUrls: ['./admin-tractores.component.scss']
})
export class AdminTractoresComponent implements OnInit {
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
      noeconomico: {
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
      this.apiEmpresas.GetTractores(this.empresaId).subscribe(data => {
        this.source.load(data);
      },
        (err) => { this.log.Falla('', 'Error al obtener trctores:' + err) },
        () => { this.loading = false; })
    });

  }

  edit(event) {
    const tractorActual: Tractor = event.data;

    this.dialogService.open(DialogoTractorComponent, {
      context: {
        title: 'Actualizar tractor',
        tractor: tractorActual
      },
    }).onClose.subscribe(tractor => {
      
      if (tractor != null) {
        this.loading = true;
        this.apiEmpresas.PutTractor(tractorActual.id, tractor).
          subscribe(
            (ok) => {
              console.log(tractor);
              this.source.update(tractorActual, tractor);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el trctor') },
            () => { this.loading = false; })
      }
    });;
  }

  create() {
    this.dialogService.open(DialogoTractorComponent, {
      context: {
        title: 'Crear Tractor',
        tractor: { id: EmptyId, empresaId: this.empresaId, noeconomico: '' }
      },
    }).onClose.subscribe(tractor => {
      if (tractor != null) {
        console.log(tractor);
        this.loading = true;
        this.apiEmpresas.PostTractor(tractor).
          subscribe(
            (ok) => {
              tractor.id = ok;
              this.source.add(tractor);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el tractor') },
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
        this.apiEmpresas.DelTractor(event.data.id).
          subscribe(
            (ok) => {
              this.source.remove(event.data);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el tractor') },
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

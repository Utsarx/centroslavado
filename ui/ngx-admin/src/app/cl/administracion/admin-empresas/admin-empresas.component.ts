import { NavegarEmpresaComponent } from './../components/navegar-empresa/navegar-empresa.component';
import { ConfirmarEliminarComponent } from './../components/confirmar-eliminar/confirmar-eliminar.component';
import { EmpresaTransporte } from './../modelos/empresa-trasnporte';
import { DialogoEmpresaComponent } from './../components/dialogo-empresa/dialogo-empresa.component';
import { Component, OnInit } from '@angular/core';
import { EmpresasService, EmptyId } from '../servicios/empresas.service';
import { LocalDataSource } from 'ng2-smart-table';
import { NbDialogService } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';

@Component({
  selector: 'ngx-admin-empresas',
  templateUrl: './admin-empresas.component.html',
  styleUrls: ['./admin-empresas.component.scss']
})
export class AdminEmpresasComponent implements OnInit {
  source: LocalDataSource = new LocalDataSource();
  loading: boolean;
  
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
    actions:{
      columnTitle: "Acciones",
    },
    columns: {
      nombre: {
        title: 'Nombre',
        type: 'string',
      },
      rfc: {
        title: 'RFC',
        type: 'string',
      },
      saldoPrepago: {
        title: 'Prepago',
        type: 'number',
        editable: false,
      },
      id: {
        title: 'Enlaces',
        type: 'custom',
        sort: false,
        filter: false,
        renderComponent: NavegarEmpresaComponent 
      },
    },
  };

  constructor(
    private log: AppLogService,
    private apiEmpresas: EmpresasService,
    private dialogService: NbDialogService) { }

  ngOnInit(): void {
    this.loading = true;
    this.apiEmpresas.GetEmpresas().subscribe(data=>{
      this.source.load(data);
    }, 
    (err)=>{ this.log.Falla('', 'Error al obtener empresas:' + err) }, 
    ()=>{this.loading = false;})
  }


  edit(event) {
    const empresaActual: EmpresaTransporte = event.data;
    this.dialogService.open(DialogoEmpresaComponent, {
      context: {
        title: 'Actualizar empresa',
        empresa: empresaActual
      },
    }).onClose.subscribe(empresa => {
      if(empresa!=null){
        this.loading = true;
        this.apiEmpresas.PutEmpresa(empresa.id, empresa).
        subscribe(
        (ok) => {
          console.log(empresa);
          this.source.update(empresaActual, empresa);
          this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'la Empresa')  },
        () => {this.loading = false;})
      }
    });;        
  }

  create() {
    this.dialogService.open(DialogoEmpresaComponent, {
      context: {
        title: 'Crear empresa',
        empresa: null
      },
    }).onClose.subscribe(empresa => {
      if(empresa!=null){
        empresa.id = EmptyId;
        this.loading = true;
        this.apiEmpresas.PostEmpresa(empresa).
        subscribe(
        (ok) => {
            empresa.id = ok;
            this.source.add(empresa);
            this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'la Empresa')  },
        () => {this.loading = false;})
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
      if(eliminar){
        this.loading = true;
        this.apiEmpresas.DelEmpresa(event.data.id).
        subscribe(
        (ok) => {
            this.source.remove(event.data);
            this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'la Empresa')  },
        () => {this.loading = false;})
      }
     
    });
  }


  onCustomAction(event) {
    console.log(event);
    // switch ( event.action) {
    //   case 'viewrecord':
    //     this.viewRecord(event.data);
    //     break;
    //  case 'editrecord':
    //     this.editRecord(event.data);
    // }
  }

  ManejarErrorHttp(err: any, tipo: string){
    this.loading = false;
    switch(parseInt(err.status)){
      case 400:
        this.log.Advertencia('', `Los datos para ${tipo} no son correctos`);
        break;

      case 500:
        this.log.Falla('', `Error de proceso para ${tipo}, consulte con el administrador`);
        break;

      default:
        break;
    }
  }

}

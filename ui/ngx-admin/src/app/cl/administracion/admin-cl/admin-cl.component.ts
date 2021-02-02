import { DialogoCentroComponent } from './../components/dialogo-centro/dialogo-centro.component';
import { CentrosService, EmptyId } from './../servicios/centros.service';
import { NavegarCentroComponent } from './../components/navegar-centro/navegar-centro.component';
import { NbDialogService } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';
import { LocalDataSource } from 'ng2-smart-table';
import { Component, OnInit } from '@angular/core';
import { CentroLavado } from '../modelos/centro-lavado';
import { ConfirmarEliminarComponent } from '../components/confirmar-eliminar/confirmar-eliminar.component';

@Component({
  selector: 'ngx-admin-cl',
  templateUrl: './admin-cl.component.html',
  styleUrls: ['./admin-cl.component.scss']
})
export class AdminClComponent implements OnInit {
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
  actions: {
    columnTitle: "Acciones",
  }, 
  columns: {
    nombre: {
      title: 'Nombre', 
      type: 'String',
    }, 
    id: {
      title: 'Enlaces', 
      type: 'custom', 
      sort: false, 
      filter: false,
      renderComponent: NavegarCentroComponent
    },
  },
}; 
  constructor(
    private log: AppLogService,
    private apiCentrosLavado: CentrosService, 
    private dialogService: NbDialogService) { }

  ngOnInit(): void {
    this.loading = true; 
    this.apiCentrosLavado.GetCentrosLavado().subscribe(
      data=>{
        this.source.load(data); 
      }, 
      (err)=>{
          this.log.Falla('', 'Error al obtener centros de lavado:' +err); 
      }, 
      ()=>{
        this.loading= false; 
      })
  }

  edit(event) {
    const centroActual: CentroLavado = event.data;
    this.dialogService.open(DialogoCentroComponent, {
      context: {
        title: 'Actualizar centro de lavado',
        centro: centroActual
      },
    }).onClose.subscribe(centro => {
      if(centro!=null){
        this.loading = true;
        this.apiCentrosLavado.PutCentroLavado(centro.id, centro).
        subscribe(
        (ok) => {
          console.log(centro);
          this.source.update(centroActual, centro);
          this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'el Centro')  },
        () => {this.loading = false;})
      }
    });;        
  }

  create() {
    
    this.dialogService.open(DialogoCentroComponent, {
      context: {
        title: 'Crear centro de lavado',
        centro: null
      },
    }).onClose.subscribe(centro => {
      if(centro!=null){
        centro.id = EmptyId;
        this.loading = true;
        this.apiCentrosLavado.PostCentroLavado(centro).
        subscribe(
        (ok) => {
            centro.id = ok;
            this.source.add(centro);
            this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'el centro')  },
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
        this.apiCentrosLavado.DelCentroLavado(event.data.id).
        subscribe(
        (ok) => {
            this.source.remove(event.data);
            this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'el centro')  },
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

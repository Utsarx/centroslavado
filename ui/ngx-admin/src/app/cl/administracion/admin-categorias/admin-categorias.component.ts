import { Categoria } from './../modelos/categoria';
import { DialogoCategoriaComponent } from './../components/dialogo-categoria/dialogo-categoria.component';
import { CategoriasService, EmptyId } from './../servicios/categorias.service';
import { Component, OnInit } from '@angular/core';
import { AppLogService } from 'app/services/app-log-service';
import { LocalDataSource } from 'ng2-smart-table';
import { NavegarCategoriaComponent } from '../components/navegar-categoria/navegar-categoria.component';
import { NbDialogService } from '@nebular/theme';
import { ConfirmarEliminarComponent } from '../components/confirmar-eliminar/confirmar-eliminar.component';

@Component({
  selector: 'ngx-admin-categorias',
  templateUrl: './admin-categorias.component.html',
  styleUrls: ['./admin-categorias.component.scss']
})
export class AdminCategoriasComponent implements OnInit {
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
      id: {
        title: 'Enlaces',
        type: 'custom',
        sort: false,
        filter: false,
        renderComponent: NavegarCategoriaComponent
      },
    },
  };


  
  constructor(  private log: AppLogService,
    private apiCategorias: CategoriasService,
    private dialogService: NbDialogService) { }

  ngOnInit(): void {
    this.loading = true;
    this.apiCategorias.GetCategorias().subscribe(
      data=>{
      this.source.load(data);
    }, 
    (err)=>{ 
      this.log.Falla('', 'Error al obtener categorías:' + err) ;
    }, 
    ()=>{
      this.loading = false;
    })
  }

  edit(event) {
    const categoActual: Categoria = event.data;
    this.dialogService.open(DialogoCategoriaComponent, {
      context: {
        title: 'Actualizar categoría',
        categoria: categoActual
      },
    }).onClose.subscribe(categoria => {
      if(categoria!=null){
        this.loading = true;
        this.apiCategorias.PutCategoria(categoria.id, categoria).
        subscribe(
        (ok) => {
          console.log(categoria);
          this.source.update(categoActual, categoria);
          this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'la Categoría')  },
        () => {this.loading = false;})
      }
    });;        
  }

  create() {
    
    this.dialogService.open(DialogoCategoriaComponent, {
      context: {
        title: 'Crear categoría',
        categoria: null
      },
    }).onClose.subscribe(categoria => {
      if(categoria!=null){
        categoria.id = EmptyId;
        this.loading = true;
        this.apiCategorias.PostCategoria(categoria).
        subscribe(
        (ok) => {
            categoria.id = ok;
            this.source.add(categoria);
            this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'la Categoría')  },
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
        this.apiCategorias.DelCategoria(event.data.id).
        subscribe(
        (ok) => {
            this.source.remove(event.data);
            this.source.refresh();
        }, 
        (err) => { this.ManejarErrorHttp(err, 'la Categoría')  },
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

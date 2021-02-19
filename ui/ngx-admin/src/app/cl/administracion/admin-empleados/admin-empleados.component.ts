import { EditorEmpleadoComponent } from './../components/editor-empleado/editor-empleado.component';
import { MostarUsuariosistemaComponent } from './../components/mostar-usuariosistema/mostar-usuariosistema.component';
import { AdminCategoriasComponent } from './../admin-categorias/admin-categorias.component';
import { Empleado } from './../modelos/empleado';
import { CentrosService, EmptyId } from './../servicios/centros.service';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NbDialogService, NbToggleComponent } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';
import { LocalDataSource } from 'ng2-smart-table';
import { first } from 'rxjs/operators';
import { DialogoEmpleadoComponent } from '../components/dialogo-empleado/dialogo-empleado.component';
import { ConfirmarEliminarComponent } from '../components/confirmar-eliminar/confirmar-eliminar.component';

@Component({
  selector: 'ngx-admin-empleados',
  templateUrl: './admin-empleados.component.html',
  styleUrls: ['./admin-empleados.component.scss']
})
export class AdminEmpleadosComponent implements OnInit {

  source: LocalDataSource = new LocalDataSource();
  loading: boolean;
  private centroLavadoId: string;
  @Input() editorEmpleadoComponent:  EditorEmpleadoComponent;

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
      usuarioSistema:{
        title: 'Tipo',
        type: 'custom',
        sort: false, 
        filter: false, 
        renderComponent: MostarUsuariosistemaComponent
      },
      id: {
        title: 'Id',
        type: 'custom',
        sort: false,
        filter: false,
        hide: true,
      },
      centroLavadoId: {
        title: 'Id centro de lavado',
        type: 'custom',
        sort: false,
        filter: false,
        hide: true,
      },
    },
  };
  constructor(private route: ActivatedRoute,
    private log: AppLogService,
    private apiCentros: CentrosService,
    private dialogService: NbDialogService) { }

  ngOnInit(): void {

    this.route.params.pipe(first()).subscribe(params => {
      
      this.centroLavadoId = params.centroLavadoId;
      this.loading = true;
      this.apiCentros.GetEmpleadosCentroLavado(this.centroLavadoId).subscribe(data => {
        this.source.load(data);
      },
        (err) => { this.log.Falla('', 'Error al obtener empleados:' + err) },
        () => { this.loading = false; })
    });

  }

  edit(event) {
    const empleadoActual: Empleado = event.data;
    
    // if(empleadoActual.usuarioSistema = true){
    //  this.editorEmpleadoComponent.toggle(true); 
    // }

    console.log(empleadoActual);
    this.dialogService.open(DialogoEmpleadoComponent, {
      context: {
        title: 'Actualizar empleado',
        empleado: empleadoActual
      },
    }).onClose.subscribe(empleado => {
      console.log(empleado);
       if (empleado != null) {
         this.loading = true;
         this.apiCentros.PutEmpleado(empleadoActual.id, empleado).
           subscribe(
             (ok) => {
               console.log(empleado);
               this.source.update(empleadoActual, empleado);
               this.source.refresh();
             },
             (err) => { this.ManejarErrorHttp(err, 'el empleado') },
             () => { this.loading = false; })
       }
    });;
  }

  create() {
    this.dialogService.open(DialogoEmpleadoComponent, {
      context: {
        title: 'Crear empleado',
        empleado: { id: EmptyId, nombre: '', usuarioSistema:false, nombreUsuario:'', hash:'', salt:'',
         centroLavadoId: this.centroLavadoId }
      },
    }).onClose.subscribe(empleado => {
      if (empleado != null) {
        this.loading = true;
        this.apiCentros.PostEmpleadoCentro(empleado, this.centroLavadoId).
          subscribe(
            (ok) => {
              empleado.id = ok;
              this.source.add(empleado);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el empleado') },
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

        this.apiCentros.RemoverEmpleado(this.centroLavadoId, event.data.id).
        subscribe(
          (ok)=>{
            this.source.remove(event.data);
            this.source.refresh(); 
          },
          (err)=> {this.ManejarErrorHttp(err, 'el empleado')},
          ()=> {this.loading = false;})
        

        this.apiCentros.DelEmpleado(event.data.id).
          subscribe(
            (ok) => {
              this.source.remove(event.data);
              this.source.refresh();
            },
            (err) => { this.ManejarErrorHttp(err, 'el empleado') },
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

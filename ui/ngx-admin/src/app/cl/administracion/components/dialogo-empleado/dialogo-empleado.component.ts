import { DialogoCentroComponent } from './../dialogo-centro/dialogo-centro.component';
import { Component, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { EditorEmpleadoComponent } from '../editor-empleado/editor-empleado.component';
import { NbDialogRef } from '@nebular/theme';
import { AppLogService } from '../../../../services/app-log-service';
import { EmptyId } from '../../servicios/categorias.service';
import { Empleado } from '../../modelos/empleado';

@Component({
  selector: 'ngx-dialogo-empleado',
  templateUrl: './dialogo-empleado.component.html',
  styleUrls: ['./dialogo-empleado.component.scss']
})
export class DialogoEmpleadoComponent implements OnInit {

  @Input() title: string;
  @Input() empleado: Empleado;
  @ViewChild(EditorEmpleadoComponent) editor: EditorEmpleadoComponent;

  public textoBoton = '';
  
  ngOnInit(): void {
    this.textoBoton = (this.empleado.id !== EmptyId) ? 'Actualizar' : 'Crear';
  }

  constructor( protected ref: NbDialogRef<DialogoCentroComponent>,
    private log: AppLogService) { 
    
  }

  ngOnChanges(changes: SimpleChanges): void {
    
  }

  procesar() {
    if(this.editor.formaEmpleado.valid){
      this.ref.close(this.editor.ObtieneEmpleado());
    } else {
      this.log.Advertencia("","Los valores introducidos no son válidos");
    }
  }

  dismiss() {
    this.ref.close(null);
  }

}

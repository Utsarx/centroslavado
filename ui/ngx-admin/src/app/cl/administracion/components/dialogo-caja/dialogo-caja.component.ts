import { Component, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';
import { Caja } from '../../modelos/caja';
import { EmptyId } from '../../servicios/empresas.service';
import { EditorCajaComponent } from '../editor-caja/editor-caja.component';

@Component({
  selector: 'ngx-dialogo-caja',
  templateUrl: './dialogo-caja.component.html',
  styleUrls: ['./dialogo-caja.component.scss']
})
export class DialogoCajaComponent implements OnInit {

  @Input() title: string;
  @Input() Caja: Caja;
  @ViewChild(EditorCajaComponent) editor: EditorCajaComponent;

  public textoBoton = '';

  ngOnInit(): void {
    this.textoBoton = (this.Caja.id !== EmptyId) ? 'Actualizar' : 'Crear';
  }

  constructor(
    protected ref: NbDialogRef<DialogoCajaComponent>,
    private log: AppLogService) {}
  
  ngOnChanges(changes: SimpleChanges): void {
    
  }

  procesar() {
    if(this.editor.formaCaja.valid){
      console.log(this.editor.ObtieneCaja());
      this.ref.close(this.editor.ObtieneCaja());
    } else {
      this.log.Advertencia("","Los valores introducidos no son válidos");
    }
  }

  dismiss() {
    this.ref.close(null);
  }
}


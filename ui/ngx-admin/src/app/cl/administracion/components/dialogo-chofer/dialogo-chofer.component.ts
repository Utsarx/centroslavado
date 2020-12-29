import { Chofer } from './../../modelos/chofer';
import { Component, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';
import { DialogoEmpresaComponent } from '../dialogo-empresa/dialogo-empresa.component';
import { EditorChoferComponent } from '../editor-chofer/editor-chofer.component';
import { EmptyId } from '../../servicios/empresas.service';

@Component({
  selector: 'ngx-dialogo-chofer',
  templateUrl: './dialogo-chofer.component.html',
  styleUrls: ['./dialogo-chofer.component.scss']
})
export class DialogoChoferComponent implements OnInit {

  @Input() title: string;
  @Input() chofer: Chofer;
  @ViewChild(EditorChoferComponent) editor: EditorChoferComponent;

  public textoBoton = '';

  ngOnInit(): void {
    this.textoBoton = (this.chofer.id !== EmptyId) ? 'Actualizar' : 'Crear';
  }

  constructor(
    protected ref: NbDialogRef<DialogoEmpresaComponent>,
    private log: AppLogService) {}
  
  ngOnChanges(changes: SimpleChanges): void {
    
  }

  procesar() {
    if(this.editor.formaChofer.valid){
      this.ref.close(this.editor.ObtieneChofer());
    } else {
      this.log.Advertencia("","Los valores introducidos no son válidos");
    }
  }

  dismiss() {
    this.ref.close(null);
  }
}

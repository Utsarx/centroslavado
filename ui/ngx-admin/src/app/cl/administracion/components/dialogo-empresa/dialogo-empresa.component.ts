import { EditorEmpresaComponent } from './../editor-empresa/editor-empresa.component';
import { EmpresaTransporte } from './../../modelos/empresa-trasnporte';
import { Component, Input, OnInit, OnChanges, SimpleChanges, ViewChild, Output, EventEmitter } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';

@Component({
  selector: 'ngx-dialogo-empresa',
  templateUrl: './dialogo-empresa.component.html',
  styleUrls: ['./dialogo-empresa.component.scss']
})
export class DialogoEmpresaComponent implements OnInit, OnChanges {
  @Input() title: string;
  @Input() empresa: EmpresaTransporte;
  @ViewChild(EditorEmpresaComponent) editor: EditorEmpresaComponent;

  public textoBoton = '';

  ngOnInit(): void {
    this.textoBoton = this.empresa ? 'Actualizar' : 'Crear';
  }

  constructor(
    protected ref: NbDialogRef<DialogoEmpresaComponent>,
    private log: AppLogService) {}
  
  ngOnChanges(changes: SimpleChanges): void {
    
  }

  procesar() {
    if(this.editor.formaEmpresa.valid){
      this.ref.close(this.editor.ObtieneEmpresa());
    } else {
      this.log.Advertencia("","Los valores introducidos no son válidos");
    }
  }

  dismiss() {
    this.ref.close(null);
  }

}

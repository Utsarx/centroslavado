import { AppLogService } from './../../../../services/app-log-service';
import { Tractor } from './../../modelos/tractor';
import { EditorTractorComponent } from './../editor-tractor/editor-tractor.component';
import { Component, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { EmptyId } from '../../servicios/empresas.service';
import { NbDialogRef } from '@nebular/theme';

@Component({
  selector: 'ngx-dialogo-tractor',
  templateUrl: './dialogo-tractor.component.html',
  styleUrls: ['./dialogo-tractor.component.scss']
})
export class DialogoTractorComponent implements OnInit {

  @Input() title: string;
  @Input() tractor: Tractor;
  @ViewChild(EditorTractorComponent) editor: EditorTractorComponent;

  public textoBoton = '';

  ngOnInit(): void {
    this.textoBoton = (this.tractor.id !== EmptyId) ? 'Actualizar' : 'Crear';
  }

  constructor(
    protected ref: NbDialogRef<DialogoTractorComponent>,
    private log: AppLogService) {}
  
  ngOnChanges(changes: SimpleChanges): void {
    
  }

  procesar() {
    if(this.editor.formaTractor.valid){
      console.log(this.editor.ObtieneTractor());
      this.ref.close(this.editor.ObtieneTractor());
    } else {
      this.log.Advertencia("","Los valores introducidos no son válidos");
    }
  }

  dismiss() {
    this.ref.close(null);
  }
}


import { EditorCentroComponent } from './../editor-centro/editor-centro.component';
import { ViewChild } from '@angular/core';
import { Input } from '@angular/core';
import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { CentroLavado } from '../../modelos/centro-lavado';
import { NbDialogRef } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';

@Component({
  selector: 'ngx-dialogo-centro',
  templateUrl: './dialogo-centro.component.html',
  styleUrls: ['./dialogo-centro.component.scss']
})
export class DialogoCentroComponent implements OnInit, OnChanges {
  @Input() title: string;
  @Input() centro: CentroLavado;
  @ViewChild(EditorCentroComponent) editor: EditorCentroComponent;

  public textoBoton = '';

  ngOnInit(): void {
    this.textoBoton = this.centro ? 'Actualizar' : 'Crear';
  }

  constructor( protected ref: NbDialogRef<DialogoCentroComponent>,
    private log: AppLogService) { }



  ngOnChanges(changes: SimpleChanges): void {
    
  }

  procesar() {
    if(this.editor.formaCentro.valid){
      this.ref.close(this.editor.ObtieneCentro());
    } else {
      this.log.Advertencia("","Los valores introducidos no son válidos");
    }
  }

  dismiss() {
    this.ref.close(null);
  }
 

}

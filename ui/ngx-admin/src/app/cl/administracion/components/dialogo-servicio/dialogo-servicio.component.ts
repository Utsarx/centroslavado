import { DialogoCategoriaComponent } from './../dialogo-categoria/dialogo-categoria.component';
import { Servicio } from './../../modelos/servicio';
import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { ViewChild } from '@angular/core';
import { EditorServicioComponent } from '../editor-servicio/editor-servicio.component';
import { EmptyId } from '../../servicios/categorias.service';
import { NbDialogRef } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';
import { SimpleChanges } from '@angular/core';

@Component({
  selector: 'ngx-dialogo-servicio',
  templateUrl: './dialogo-servicio.component.html',
  styleUrls: ['./dialogo-servicio.component.scss']
})
export class DialogoServicioComponent implements OnInit {
  @Input() title: string;
  @Input() servicio: Servicio;
  @ViewChild(EditorServicioComponent) editor: EditorServicioComponent;

  public textoBoton = '';


  ngOnInit(): void {
    this.textoBoton = (this.servicio.id !== EmptyId) ? 'Actualizar' : 'Crear';
  }

  constructor( protected ref: NbDialogRef<DialogoCategoriaComponent>,
    private log: AppLogService) { }

    ngOnChanges(changes: SimpleChanges): void {
    
    }

    
    procesar() {
      if(this.editor.formaServicio.valid){
        this.ref.close(this.editor.ObtieneServicio());
      } else {
        this.log.Advertencia("","Los valores introducidos no son válidos");
      }
    }

    dismiss() {
      this.ref.close(null);
    }
}

import { EditorCategoriaComponent } from './../editor-categoria/editor-categoria.component';
import { Component, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { Categoria } from '../../modelos/categoria';
import { NbDialogRef } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';

@Component({
  selector: 'ngx-dialogo-categoria',
  templateUrl: './dialogo-categoria.component.html',
  styleUrls: ['./dialogo-categoria.component.scss']
})
export class DialogoCategoriaComponent implements OnInit {
  @Input() title: string;
  @Input() categoria: Categoria;
  @ViewChild(EditorCategoriaComponent) editor: EditorCategoriaComponent;

  public textoBoton = '';

  ngOnInit(): void {
    this.textoBoton = this.categoria ? 'Actualizar' : 'Crear';
  }

  constructor(protected ref: NbDialogRef<DialogoCategoriaComponent>,
    private log: AppLogService) { }
 
    ngOnChanges(changes: SimpleChanges): void {
    
    }

    procesar() {
      if(this.editor.formaCategoria.valid){
        this.ref.close(this.editor.ObtieneCategoria());
      } else {
        this.log.Advertencia("","Los valores introducidos no son válidos");
      }
    }
  
    dismiss() {
      this.ref.close(null);
    }

}

import { DialogoCategoriaComponent } from './../dialogo-categoria/dialogo-categoria.component';
import { EditorPrecioComponent } from './../editor-precio/editor-precio.component';
import { Component, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { Precio } from '../../modelos/precio';
import { EmptyId } from '../../servicios/categorias.service';
import { NbDialogRef } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';

@Component({
  selector: 'ngx-dialogo-precio',
  templateUrl: './dialogo-precio.component.html',
  styleUrls: ['./dialogo-precio.component.scss']
})
export class DialogoPrecioComponent implements OnInit {

  @Input() title: string;
  @Input() precio: Precio;
  @ViewChild(EditorPrecioComponent) editor: EditorPrecioComponent;
  
  public textoBoton = '';

  ngOnInit(): void {
    this.textoBoton = (this.precio.id !== EmptyId) ? 'Actualizar' : 'Crear';
  }

  constructor(protected ref: NbDialogRef<DialogoCategoriaComponent>,
    private log: AppLogService) { }

    ngOnChanges(changes: SimpleChanges): void {
    
    }

    procesar() {
      if(this.editor.formaPrecio.valid){
        this.ref.close(this.editor.ObtienePrecio());
      } else {
        this.log.Advertencia("","Los valores introducidos no son válidos");
      }
    }
  
    dismiss() {
      this.ref.close(null);
    }

}

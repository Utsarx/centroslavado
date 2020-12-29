import { Component, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { NbDialogRef } from '@nebular/theme';
import { DialogoEmpresaComponent } from '../dialogo-empresa/dialogo-empresa.component';

@Component({
  selector: 'ngx-confirmar-eliminar',
  templateUrl: './confirmar-eliminar.component.html',
  styleUrls: ['./confirmar-eliminar.component.scss']
})
export class ConfirmarEliminarComponent implements OnInit {

  @Input() nombre: string;


  public textoBoton = '';

  ngOnInit(): void {

  }

  constructor(
    protected ref: NbDialogRef<DialogoEmpresaComponent>,
    ) { }

  ngOnChanges(changes: SimpleChanges): void {

  }

  eliminar() {
    this.ref.close(true);
  }

  dismiss() {
    this.ref.close(false);
  }
}

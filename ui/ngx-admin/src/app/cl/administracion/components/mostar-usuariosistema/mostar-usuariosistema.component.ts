import { Component, Input, OnInit } from '@angular/core';
import { Empleado } from '../../modelos/empleado';

@Component({
  selector: 'ngx-mostar-usuariosistema',
  templateUrl: './mostar-usuariosistema.component.html',
  styleUrls: ['./mostar-usuariosistema.component.scss']
})
export class MostarUsuariosistemaComponent implements OnInit {

  constructor() { }

  @Input() rowData: any;
  

  ngOnInit(): void {
    console.log(this.rowData);
  }

  
  

}

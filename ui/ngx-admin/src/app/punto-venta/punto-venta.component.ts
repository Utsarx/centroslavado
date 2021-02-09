import { Component, OnInit } from '@angular/core';
import { MENU_ITEMS } from 'app/activos/cl-menu';

@Component({
  selector: 'ngx-punto-venta',
  styleUrls: ['./punto-venta.component.scss'],
  template: `
  <ngx-one-column-layout>
    <nb-menu [items]="menu"></nb-menu>
    <router-outlet></router-outlet>
  </ngx-one-column-layout>
`,
})
export class PuntoVentaComponent implements OnInit {
  menu = MENU_ITEMS;
  constructor() { }

  ngOnInit(): void {
  }

}

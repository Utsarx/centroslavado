import { Component } from '@angular/core';

import { MENU_ITEMS } from './cl-menu';

@Component({
  selector: 'ngx-cl',
  styleUrls: ['cl.component.scss'],
  template: `
    <ngx-one-column-layout>
      <nb-menu [items]="menu"></nb-menu>
      <router-outlet></router-outlet>
    </ngx-one-column-layout>
  `,
})
export class ClComponent {

  menu = MENU_ITEMS;
}

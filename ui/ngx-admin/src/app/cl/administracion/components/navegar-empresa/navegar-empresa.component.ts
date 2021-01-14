import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { ViewCell } from 'ng2-smart-table';

@Component({
  selector: 'ngx-navegar-empresa',
  templateUrl: './navegar-empresa.component.html',
  styleUrls: ['./navegar-empresa.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class NavegarEmpresaComponent  implements ViewCell {
  
  constructor(private router: Router) { }

  @Input() value: string | number;
  @Input() rowData: any;
  renderValue: string;

  ngOnInit() {
  }

  NavegarChoferes(){
    this.router.navigate(['/choferes', { empresaId: this.value }]); 
  }

  NavegarCajas(){
    this.router.navigate(['/cajas', { empresaId: this.value }]); 
  }

  NavegarTractores(){
    this.router.navigate(['/tractores', { empresaId: this.value }]); 
  }
  
}

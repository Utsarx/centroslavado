import { ViewCell } from 'ng2-smart-table';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { Input } from '@angular/core';

@Component({
  selector: 'ngx-navegar-centro',
  templateUrl: './navegar-centro.component.html',
  styleUrls: ['./navegar-centro.component.scss'], 
  encapsulation: ViewEncapsulation.None

})
export class NavegarCentroComponent implements ViewCell {

  constructor(private router: Router) { }
  @Input() value: string | number;
  @Input() rowData: any;
  renderValue: string;

  ngOnInit() {
  }

    NavegarEmpleados(){
      this.router.navigate(['/empleados', {centroLavadoId: this.value}]);
    }

}

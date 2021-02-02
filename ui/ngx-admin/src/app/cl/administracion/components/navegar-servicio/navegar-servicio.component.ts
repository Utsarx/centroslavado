import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-navegar-servicio',
  templateUrl: './navegar-servicio.component.html',
  styleUrls: ['./navegar-servicio.component.scss']
})
export class NavegarServicioComponent implements OnInit {

  constructor(private router: Router) { }

  @Input() value: string | number;
  @Input() rowData: any;
  renderValue: string;

  ngOnInit(): void {
  }
  
  NavegarPrecios(){
    this.router.navigate(['/precios', { servicioId: this.value }]); 
}

}

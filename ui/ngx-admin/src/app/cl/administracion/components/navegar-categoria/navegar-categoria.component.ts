import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-navegar-categoria',
  templateUrl: './navegar-categoria.component.html',
  styleUrls: ['./navegar-categoria.component.scss']
})
export class NavegarCategoriaComponent implements OnInit {

  constructor(private router: Router) { }
  @Input() value: string | number;
  @Input() rowData: any;
  renderValue: string;

  ngOnInit(): void {
  }
  NavegarServicios(){
    this.router.navigate(['/servicios', { categoriaId: this.value }]); 
  }
}

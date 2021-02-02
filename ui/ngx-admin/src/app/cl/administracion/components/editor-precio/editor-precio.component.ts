import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Precio } from '../../modelos/precio';


@Component({
  selector: 'ngx-editor-precio',
  templateUrl: './editor-precio.component.html',
  styleUrls: ['./editor-precio.component.scss']
})
export class EditorPrecioComponent implements OnInit {

  @Input() precio: Precio 

  public formaPrecio: FormGroup;


  constructor(private fb: FormBuilder,) { 

    this.formaPrecio = this.fb.group({
      id: '',
      descripcion: '',
      monto: '',
      servicioId:'',
    });

    this.formaPrecio.valueChanges.subscribe(v=>{
      console.log(v);
    })


  }


  public ObtienePrecio(): Precio {
    return { 
      id: this.formaPrecio.get('id').value ,
      descripcion: this.formaPrecio.get('descripcion').value,
      monto:  Number.parseFloat( this.formaPrecio.get('monto').value),
      moneda: 0,
      esDefault: false,
      servicioId: this.formaPrecio.get('servicioId').value,
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {
    console.log(this.precio);
     if (this.precio!=null){
      this.formaPrecio.get('id').setValue(this.precio.id);
      this.formaPrecio.get('descripcion').setValue(this.precio.descripcion);
      this.formaPrecio.get('servicioId').setValue(this.precio.servicioId);
     }

  }
  ngOnInit(): void {
  }

}

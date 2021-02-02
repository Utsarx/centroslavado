import { Servicio } from './../../modelos/servicio';
import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { SimpleChanges } from '@angular/core';

@Component({
  selector: 'ngx-editor-servicio',
  templateUrl: './editor-servicio.component.html',
  styleUrls: ['./editor-servicio.component.scss']
})
export class EditorServicioComponent implements OnInit {

  @Input() servicio: Servicio;

  public formaServicio: FormGroup;

  constructor(private fb: FormBuilder,) {
    
    this.formaServicio = this.fb.group({
      id: '',
      nombre: '',
      clave:'',
      categoriaId: '',
    });

    this.formaServicio.valueChanges.subscribe(v=>{
      console.log(v);
    })
   }

   public ObtieneServicio(): Servicio {
    return { 
      id: this.formaServicio.get('id').value ,
      nombre: this.formaServicio.get('nombre').value,
      clave: this.formaServicio.get('clave').value,
      categoriaId: this.formaServicio.get('categoriaId').value
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {
    if (this.servicio!=null){
     this.formaServicio.get('id').setValue(this.servicio.id);
     this.formaServicio.get('nombre').setValue(this.servicio.nombre);
     this.formaServicio.get('clave').setValue(this.servicio.clave);
     this.formaServicio.get('categoriaId').setValue(this.servicio.categoriaId);
    }

 }

  ngOnInit(): void {
  }

}

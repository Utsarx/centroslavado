import { Component, OnInit, OnChanges, SimpleChanges, Input } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { Categoria } from '../../modelos/categoria';

@Component({
  selector: 'ngx-editor-categoria',
  templateUrl: './editor-categoria.component.html',
  styleUrls: ['./editor-categoria.component.scss']
})
export class EditorCategoriaComponent implements OnInit, OnChanges {
  @Input() categoria: Categoria
  public formaCategoria: FormGroup;

  constructor(private fb: FormBuilder,) { 

    this.formaCategoria = this.fb.group({
      id: '',
      nombre: '',
    });

    this.formaCategoria.valueChanges.subscribe(v=>{
      console.log(v);
    })
  }

  public ObtieneCategoria(): Categoria {
    return { 
      id: this.formaCategoria.get('id').value ,
      nombre: this.formaCategoria.get('nombre').value,
      servicios: null,
     }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {
    if(this.categoria!=null){
      this.formaCategoria.get('id').setValue(this.categoria.id);
      this.formaCategoria.get('nombre').setValue(this.categoria.nombre);
    }
    }
  ngOnInit(): void {
  }

}

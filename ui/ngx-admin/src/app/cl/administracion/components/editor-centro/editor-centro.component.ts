import { Input } from '@angular/core';
import { Component, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { CentroLavado } from '../../modelos/centro-lavado';

@Component({
  selector: 'ngx-editor-centro',
  templateUrl: './editor-centro.component.html',
  styleUrls: ['./editor-centro.component.scss']
})
export class EditorCentroComponent implements OnInit, OnChanges {

  
  @Input() centro: CentroLavado

  public formaCentro: FormGroup;


  constructor(private fb: FormBuilder,) { 
    this.formaCentro = this.fb.group({
      id: '',
      nombre: '',

    });

    this.formaCentro.valueChanges.subscribe(v=>{
      console.log(v);
    })

  }

  public ObtieneCentro(): CentroLavado {
    return { 
      id: this.formaCentro.get('id').value,
      nombre: this.formaCentro.get('nombre').value,
      empleados: null,
            }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {
    if(this.centro!=null){
      this.formaCentro.get('id').setValue(this.centro.id);
      this.formaCentro.get('nombre').setValue(this.centro.nombre);
    }
    }
    
  ngOnInit(): void {
  }

}

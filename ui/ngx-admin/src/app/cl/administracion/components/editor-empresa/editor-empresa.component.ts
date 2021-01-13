import { EmpresaTransporte } from './../../modelos/empresa-trasnporte';
import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'ngx-editor-empresa',
  templateUrl: './editor-empresa.component.html',
  styleUrls: ['./editor-empresa.component.scss']
})
export class EditorEmpresaComponent implements OnInit, OnChanges {

  @Input() empresa: EmpresaTransporte

  public formaEmpresa: FormGroup;

  constructor(private fb: FormBuilder,) { 

    this.formaEmpresa = this.fb.group({
      id: '',
      nombre: '',
      rfc: '',
    });

    this.formaEmpresa.valueChanges.subscribe(v=>{
      console.log(v);
    })

  }

  public ObtieneEmpresa(): EmpresaTransporte {
    return { 
      id: this.formaEmpresa.get('id').value ,
      nombre: this.formaEmpresa.get('nombre').value,
      rfc: this.formaEmpresa.get('rfc').value,
      saldoPrepago: 0, // El valor del prepgado no se actualiza vía la forma
      tractores: null,
      choferes: null,
      cajas: null }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {
    if(this.empresa!=null){
      this.formaEmpresa.get('id').setValue(this.empresa.id);
      this.formaEmpresa.get('nombre').setValue(this.empresa.nombre);
      this.formaEmpresa.get('rfc').setValue(this.empresa.rfc);
    }
    }

  ngOnInit(): void {
  }

}

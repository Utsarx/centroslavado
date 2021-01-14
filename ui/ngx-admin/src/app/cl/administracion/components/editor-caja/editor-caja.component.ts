import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Caja } from '../../modelos/caja';

@Component({
  selector: 'ngx-editor-caja',
  templateUrl: './editor-caja.component.html',
  styleUrls: ['./editor-caja.component.scss']
})
export class EditorCajaComponent implements OnInit, OnChanges {

  @Input() caja: Caja;

  public formaCaja: FormGroup;

  constructor(private fb: FormBuilder,) { 

    this.formaCaja = this.fb.group({
      id: '',
      noeconomico: '',
      empresaId: '',
    });

    this.formaCaja.valueChanges.subscribe(v=>{
      console.log(v);
    })

  }

  public ObtieneCaja(): Caja {
    return { 
      id: this.formaCaja.get('id').value ,
      noEconomico: this.formaCaja.get('noEconomico').value,
      empresaId: this.formaCaja.get('empresaId').value
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {
    console.log(this.caja);
     if (this.caja!=null){
      this.formaCaja.get('id').setValue(this.caja.id);
      this.formaCaja.get('noeconomico').setValue(this.caja.noEconomico);
      this.formaCaja.get('empresaId').setValue(this.caja.empresaId);
     }

  }

  ngOnInit(): void {
  }
}

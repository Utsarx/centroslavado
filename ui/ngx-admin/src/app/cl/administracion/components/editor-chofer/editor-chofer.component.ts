import { Chofer } from './../../modelos/chofer';
import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'ngx-editor-chofer',
  templateUrl: './editor-chofer.component.html',
  styleUrls: ['./editor-chofer.component.scss']
})
export class EditorChoferComponent implements OnInit, OnChanges {

  @Input() chofer: Chofer;

  public formaChofer: FormGroup;

  constructor(private fb: FormBuilder,) { 

    this.formaChofer = this.fb.group({
      id: '',
      nombre: '',
      empresaId: '',
    });

    this.formaChofer.valueChanges.subscribe(v=>{
      console.log(v);
    })

  }

  public ObtieneChofer(): Chofer {
    return { 
      id: this.formaChofer.get('id').value ,
      nombre: this.formaChofer.get('nombre').value,
      empresaId: this.formaChofer.get('empresaId').value
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {
     if (this.chofer!=null){
      this.formaChofer.get('id').setValue(this.chofer.id);
      this.formaChofer.get('nombre').setValue(this.chofer.nombre);
      this.formaChofer.get('empresaId').setValue(this.chofer.empresaId);
     }

  }

  ngOnInit(): void {
  }

}

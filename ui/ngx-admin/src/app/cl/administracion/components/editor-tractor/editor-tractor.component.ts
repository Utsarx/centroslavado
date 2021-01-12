import { Tractor } from './../../modelos/tractor';
import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'ngx-editor-tractor',
  templateUrl: './editor-tractor.component.html',
  styleUrls: ['./editor-tractor.component.scss']
})
export class EditorTractorComponent implements OnInit, OnChanges {

  @Input() tractor: Tractor;

  public formaTractor: FormGroup;

  constructor(private fb: FormBuilder,) { 

    this.formaTractor = this.fb.group({
      id: '',
      noeconomico: '',
      empresaId: '',
    });

    this.formaTractor.valueChanges.subscribe(v=>{
      console.log(v);
    })

  }

  public ObtieneTractor(): Tractor {
    return { 
      id: this.formaTractor.get('id').value ,
      noeconomico: this.formaTractor.get('noeconomico').value,
      empresaId: this.formaTractor.get('empresaId').value
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {
    console.log(this.tractor);
     if (this.tractor!=null){
      this.formaTractor.get('id').setValue(this.tractor.id);
      this.formaTractor.get('noeconomico').setValue(this.tractor.noeconomico);
      this.formaTractor.get('empresaId').setValue(this.tractor.empresaId);
     }

  }

  ngOnInit(): void {
  }
}

import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AppLogService } from '../../../../services/app-log-service';
import { Empleado } from '../../modelos/empleado';

@Component({
  selector: 'ngx-editor-empleado',
  templateUrl: './editor-empleado.component.html',
  styleUrls: ['./editor-empleado.component.scss']
})
export class EditorEmpleadoComponent implements OnInit {

  @Input() empleado: Empleado; 
  public formaEmpleado: FormGroup;
  public mostrarTodo: boolean; 


  constructor(private fb: FormBuilder,
    private log: AppLogService,) { 

    this.formaEmpleado = this.fb.group({
      id: '',
      nombre: '',
      usuarioSistema:'',
      nombreUsuario:'', 
      hash: '', 
      salt: '',
      centroLavadoId: '',
    });

    this.formaEmpleado.valueChanges.subscribe(v=>{
      console.log(v);
    })
  }

  public toggle(activo:boolean){
    console.log(activo); 
    this.mostrarTodo=activo; 
  }

  public ObtieneEmpleado(): Empleado {
    return { 
      id: this.formaEmpleado.get('id').value ,
      nombre: this.formaEmpleado.get('nombre').value,
      usuarioSistema: (this.formaEmpleado.get('usuarioSistema').value), 
      nombreUsuario: (this.formaEmpleado.get('usuarioSistema').value) == true ? this.formaEmpleado.get('nombreUsuario').value: null,
      hash: this.formaEmpleado.get('hash').value, 
      salt: this.formaEmpleado.get('salt').value,
      //Activo: this.formaEmpleado.get('activo').value,
      centroLavadoId: this.formaEmpleado.get('centroLavadoId').value
    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.UpdateUI();
  }

  private UpdateUI() {

     if (this.empleado!=null){
      this.mostrarTodo = this.empleado.usuarioSistema;
      this.formaEmpleado.get('id').setValue(this.empleado.id);
      this.formaEmpleado.get('nombre').setValue(this.empleado.nombre);
      this.formaEmpleado.get('usuarioSistema').setValue(this.empleado.usuarioSistema); 
      this.formaEmpleado.get('nombreUsuario').setValue(this.empleado.nombreUsuario); 
      this.formaEmpleado.get('hash').setValue(this.empleado.hash); 
      this.formaEmpleado.get('salt').setValue(this.empleado.salt); 
      //this.formaEmpleado.get('activo').setValue(true); 
      this.formaEmpleado.get('centroLavadoId').setValue(this.empleado.centroLavadoId);
     }

  }
  ngOnInit(): void {
  }

}

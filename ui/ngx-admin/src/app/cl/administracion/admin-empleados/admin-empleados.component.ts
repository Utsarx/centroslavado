import { Empleado } from './../modelos/empleado';
import { CentrosService } from './../servicios/centros.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NbDialogService } from '@nebular/theme';
import { AppLogService } from 'app/services/app-log-service';
import { LocalDataSource } from 'ng2-smart-table';
import { first } from 'rxjs/operators';
import { EmpresasService } from '../servicios/empresas.service';

@Component({
  selector: 'ngx-admin-empleados',
  templateUrl: './admin-empleados.component.html',
  styleUrls: ['./admin-empleados.component.scss']
})
export class AdminEmpleadosComponent implements OnInit {

  source: LocalDataSource = new LocalDataSource();
  loading: boolean;
  private centroLavadoId: string;

  settings = {
    mode: 'external',
    add: {
      addButtonContent: '<i class="nb-plus"></i>',
      createButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    edit: {
      editButtonContent: '<i class="nb-edit"></i>',
      saveButtonContent: '<i class="nb-checkmark"></i>',
      cancelButtonContent: '<i class="nb-close"></i>',
    },
    delete: {
      deleteButtonContent: '<i class="nb-trash"></i>',
      confirmDelete: true,
    },
    actions: {
      columnTitle: "Acciones",
    },
    columns: {
      nombre: {
        title: 'Nombre',
        type: 'string',
      },
      id: {
        title: 'Id',
        type: 'custom',
        sort: false,
        filter: false,
        hide: true,
      },
      centroLavadoId: {
        title: 'Id centro de lavado',
        type: 'custom',
        sort: false,
        filter: false,
        hide: true,
      },
    },
  };
  constructor(private route: ActivatedRoute,
    private log: AppLogService,
    private apiCentros: CentrosService,
    private dialogService: NbDialogService) { }

  ngOnInit(): void {

 
  }

 
}

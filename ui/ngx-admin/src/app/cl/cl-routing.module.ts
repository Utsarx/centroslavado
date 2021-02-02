import { AdminPreciosComponent } from './administracion/admin-precios/admin-precios.component';
import { AdminCategoriasComponent } from './administracion/admin-categorias/admin-categorias.component';
import { AdminEmpleadosComponent } from './administracion/admin-empleados/admin-empleados.component';
import { AdminClComponent } from './administracion/admin-cl/admin-cl.component';
import { AdminTractoresComponent } from './administracion/admin-tractores/admin-tractores.component';
import { AdminChoferesComponent } from './administracion/admin-choferes/admin-choferes.component';
import { AdminEmpresasComponent } from './administracion/admin-empresas/admin-empresas.component';
import { AdminCajasComponent } from './administracion/admin-cajas/admin-cajas.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule, Component } from '@angular/core';

import { ClComponent } from './cl.component';
import { AuthGuard } from 'app/services/auth-guard';
import { AdminServiciosComponent } from './administracion/admin-servicios/admin-servicios.component';


const routes: Routes = [{
  path: '',
  component: ClComponent,
  children: [
    {
      path: 'empresas',
      component: AdminEmpresasComponent,
    },
    {
      path: 'choferes',
      component: AdminChoferesComponent,
    }, 
    {
      path: 'tractores',
      component: AdminTractoresComponent,
    },
    {
      path: 'cajas', 
      component: AdminCajasComponent,
    },
    {
      path: 'centros', 
      component: AdminClComponent,
    },
  
    {
      path: 'empleados', 
      component: AdminEmpleadosComponent,
    },
    {
      path: 'categorias', 
      component: AdminCategoriasComponent,
    },
    {
      path: 'servicios', 
      component: AdminServiciosComponent,
    },
    {
      path: 'precios', 
      component: AdminPreciosComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClRoutingModule {
}

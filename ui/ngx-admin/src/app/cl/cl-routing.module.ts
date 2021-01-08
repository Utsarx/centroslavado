import { AdminChoferesComponent } from './administracion/admin-choferes/admin-choferes.component';
import { AdminEmpresasComponent } from './administracion/admin-empresas/admin-empresas.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { ClComponent } from './cl.component';
import { AuthGuard } from 'app/services/auth-guard';

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
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClRoutingModule {
}

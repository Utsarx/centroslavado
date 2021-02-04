import { ConsultaComponent } from './consulta/consulta.component';
import { TerminalComponent } from './terminal/terminal.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PuntoVentaComponent} from './punto-venta.component';
import { AuthGuard } from 'app/services/auth-guard';

const routes: Routes = [{
  path: '',
  component: PuntoVentaComponent,
  children: [
    {
      path: 'terminal',
      component: TerminalComponent,
    },
    {
      path: 'consulta',
      component: ConsultaComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class PuntoVentaRoutingModule {
}

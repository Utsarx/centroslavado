import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from './services/auth-guard';

export const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    loadChildren: () => import('./cl/cl.module')
      .then(m => m.ClModule),
  },
  {
    path: '',
    canActivate: [AuthGuard],
    loadChildren: () => import('./punto-venta/punto-venta.module')
      .then(m => m.PuntoVentaModule),
  },
  {
    path: 'pages',
    loadChildren: () => import('./pages/pages.module')
      .then(m => m.PagesModule),
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module')
      .then(m => m.NgxAuthModule),
  },
  { path: '', redirectTo: 'empresas', pathMatch: 'full' },
  { path: '**', redirectTo: 'empresas' },
];

const config: ExtraOptions = {
  useHash: false,
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}

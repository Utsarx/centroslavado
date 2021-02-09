import { ClRoutingModule } from './cl-routing.module';
import { NavegarEmpresaComponent } from './administracion/components/navegar-empresa/navegar-empresa.component';
import { NgModule } from '@angular/core';
import { NbMenuModule, NbCardModule, NbDialogModule, NbButtonModule, NbInputModule, NbSpinnerModule,
  NbActionsModule, NbIconModule, NbTooltipModule } from '@nebular/theme';
import { ThemeModule } from '../@theme/theme.module';
import { ClComponent } from './cl.component';
import { AdminEmpresasComponent } from './administracion/admin-empresas/admin-empresas.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { EditorEmpresaComponent } from './administracion/components/editor-empresa/editor-empresa.component';
import { DialogoEmpresaComponent } from './administracion/components/dialogo-empresa/dialogo-empresa.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfirmarEliminarComponent } from './administracion/components/confirmar-eliminar/confirmar-eliminar.component';
import { AdminChoferesComponent } from './administracion/admin-choferes/admin-choferes.component';
import { DialogoChoferComponent } from './administracion/components/dialogo-chofer/dialogo-chofer.component';
import { EditorChoferComponent } from './administracion/components/editor-chofer/editor-chofer.component';
import { AdminTractoresComponent } from './administracion/admin-tractores/admin-tractores.component';
import { DialogoTractorComponent } from './administracion/components/dialogo-tractor/dialogo-tractor.component';
import { EditorTractorComponent } from './administracion/components/editor-tractor/editor-tractor.component';
import { DialogoCajaComponent } from './administracion/components/dialogo-caja/dialogo-caja.component';
import { EditorCajaComponent } from './administracion/components/editor-caja/editor-caja.component';
import { AdminCajasComponent } from './administracion/admin-cajas/admin-cajas.component';
import { AdminClComponent } from './administracion/admin-cl/admin-cl.component';
import { NavegarCentroComponent } from './administracion/components/navegar-centro/navegar-centro.component';
import { DialogoCentroComponent } from './administracion/components/dialogo-centro/dialogo-centro.component';
import { EditorCentroComponent } from './administracion/components/editor-centro/editor-centro.component';
import { AdminEmpleadosComponent } from './administracion/admin-empleados/admin-empleados.component';
import { AdminCategoriasComponent } from './administracion/admin-categorias/admin-categorias.component';
import { NavegarCategoriaComponent } from './administracion/components/navegar-categoria/navegar-categoria.component';
import { AdminServiciosComponent } from './administracion/admin-servicios/admin-servicios.component';
import { DialogoCategoriaComponent } from './administracion/components/dialogo-categoria/dialogo-categoria.component';
import { EditorCategoriaComponent } from './administracion/components/editor-categoria/editor-categoria.component';
import { DialogoServicioComponent } from './administracion/components/dialogo-servicio/dialogo-servicio.component';
import { EditorServicioComponent } from './administracion/components/editor-servicio/editor-servicio.component';
import { NavegarServicioComponent } from './administracion/components/navegar-servicio/navegar-servicio.component';
import { AdminPreciosComponent } from './administracion/admin-precios/admin-precios.component';
import { DialogoPrecioComponent } from './administracion/components/dialogo-precio/dialogo-precio.component';
import { EditorPrecioComponent } from './administracion/components/editor-precio/editor-precio.component';

@NgModule({
  imports: [
    FormsModule,
    NbTooltipModule,
    ReactiveFormsModule,
    ThemeModule,
    NbSpinnerModule,
    NbActionsModule,
    NbMenuModule,
    NbIconModule,
    ClRoutingModule,
    Ng2SmartTableModule,
    NbCardModule,
    NbDialogModule,
    NbButtonModule,
    NbInputModule
  ],
  declarations: [
    ClComponent,
    AdminEmpresasComponent,
    EditorEmpresaComponent,
    DialogoEmpresaComponent,
    ConfirmarEliminarComponent,
    NavegarEmpresaComponent,
    AdminChoferesComponent,
    DialogoChoferComponent,
    EditorChoferComponent,
    AdminTractoresComponent,
    DialogoTractorComponent,
    EditorTractorComponent,
    DialogoCajaComponent,
    EditorCajaComponent,
    AdminCajasComponent,
    AdminClComponent,
    NavegarCentroComponent,
    DialogoCentroComponent,
    EditorCentroComponent,
    AdminEmpleadosComponent,
    AdminCategoriasComponent,
    NavegarCategoriaComponent,
    AdminServiciosComponent,
    DialogoCategoriaComponent,
    EditorCategoriaComponent,
    DialogoServicioComponent,
    EditorServicioComponent,
    NavegarServicioComponent,
    AdminPreciosComponent,
    DialogoPrecioComponent,
    EditorPrecioComponent, //x
  ],
})
export class ClModule {
}

import { ClRoutingModule } from './cl-routing.module';
import { NavegarEmpresaComponent } from './administracion/components/navegar-empresa/navegar-empresa.component';
import { NgModule } from '@angular/core';
import { NbMenuModule, NbCardModule, NbDialogModule, NbButtonModule, NbInputModule, NbSpinnerModule, NbActionsModule, NbIconModule, NbTooltipModule } from '@nebular/theme';
import { ThemeModule } from '../@theme/theme.module';
import { ClComponent } from './cl.component';
import { AdminEmpresasComponent } from './administracion/admin-empresas/admin-empresas.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { Ng2CompleterModule } from 'ng2-completer';
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
    Ng2CompleterModule,
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
  ],
})
export class ClModule {
}

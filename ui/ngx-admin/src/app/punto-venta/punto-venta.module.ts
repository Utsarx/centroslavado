import { PuntoVentaRoutingModule } from './punto-venta-routing';
import { NgModule } from '@angular/core';
import { PuntoVentaComponent } from './punto-venta.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NbTooltipModule, NbSpinnerModule, NbActionsModule, NbMenuModule, NbIconModule, 
  NbCardModule, NbDialogModule, NbButtonModule, NbInputModule } from '@nebular/theme';
import { ThemeModule } from 'app/@theme/theme.module';
import { Ng2CompleterModule } from 'ng2-completer';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { TerminalComponent } from './terminal/terminal.component';
import { ConsultaComponent } from './consulta/consulta.component';



@NgModule({
  declarations: [PuntoVentaComponent, TerminalComponent, ConsultaComponent],
  imports: [
    FormsModule,
    NbTooltipModule,
    ReactiveFormsModule,
    ThemeModule,
    NbSpinnerModule,
    NbActionsModule,
    NbMenuModule,
    NbIconModule,
    PuntoVentaRoutingModule,
    Ng2CompleterModule,
    Ng2SmartTableModule,
    NbCardModule,
    NbDialogModule,
    NbButtonModule,
    NbInputModule
  ],
})
export class PuntoVentaModule { }

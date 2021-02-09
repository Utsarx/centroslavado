import { PuntoVentaRoutingModule } from './punto-venta-routing';
import { NgModule } from '@angular/core';
import { PuntoVentaComponent } from './punto-venta.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NbTooltipModule, NbSpinnerModule, NbActionsModule, NbMenuModule, NbIconModule, 
  NbCardModule, NbDialogModule, NbButtonModule, NbInputModule, NbSelectModule, NbAutocompleteModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { TerminalComponent } from './terminal/terminal.component';
import { ConsultaComponent } from './consulta/consulta.component';
import { SelectorPvComponent } from './components/selector-pv/selector-pv.component';
import { ThemeModule } from '../@theme/theme.module';



@NgModule({
  declarations: [PuntoVentaComponent, TerminalComponent, ConsultaComponent, SelectorPvComponent],
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
    Ng2SmartTableModule,
    NbCardModule,
    NbDialogModule,
    NbButtonModule,
    NbInputModule,
    NbSelectModule,
    NbAutocompleteModule,
  ],
})
export class PuntoVentaModule { }

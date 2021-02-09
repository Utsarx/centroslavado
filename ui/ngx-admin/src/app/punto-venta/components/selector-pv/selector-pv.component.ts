import { Servicio, Precio } from './../../modelos/configuracion-ventae-centrollavado';
import { ParOrdenado } from './../../modelos/par-ordenado';
import { Component, OnInit } from '@angular/core';
import { AsyncSubject, Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { first, map, startWith } from 'rxjs/operators';
import { TerminalServices } from '../../services/terminal-services';
import { ConfiguracionVentaeCentroLavado } from '../../modelos/configuracion-ventae-centrollavado';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'ngx-selector-pv',
  templateUrl: './selector-pv.component.html',
  styleUrls: ['./selector-pv.component.scss']
})
export class SelectorPvComponent implements OnInit {

  public empresasFiltradas$: Observable<ParOrdenado[]>;
  public vehiculosFiltrados$: Observable<ParOrdenado[]>;

  public inputEmpresas: FormControl;
  public inputVehiculos: FormControl;

  public centrolavado: string;
  public servicio: string;
  public empresa: string;
  public vehiculo: string;
  public precio: string;

  private opcionesVehiculos: ParOrdenado[];
  private opcionesEmpresa: ParOrdenado[];
  private selected: boolean;
  public configuracion: ConfiguracionVentaeCentroLavado[];
  public servicios: Servicio[];
  public precios: Precio[];


  private  CENTROLAVADOID = 'CentroLavadoId';
  private  CATEGORIAID = 'CategoriaId';
  private  SERVICIOID = 'ServicioId';
  private  PRECIOID = 'PrecioId';
  private  MONTO = 'Monto';
  private  MONEDA = 'Moneda';
  private  EMPRESATRANSPORTEID = 'EmpresaTransporteId';
  private  TRACTORID = 'TractorId';

  selectorform = new FormGroup({
    CentroLavadoId: new FormControl('',  Validators.required),
    CategoriaId: new FormControl('',  Validators.required),
    ServicioId: new FormControl('',  Validators.required),
    PrecioId: new FormControl('',  Validators.required),
    Monto: new FormControl('',  Validators.required),
    EmpresaTransporteId: new FormControl('',  Validators.required),
    TractorId: new FormControl('', Validators.required),
    Moneda: new FormControl('', Validators.required),
  });


  constructor(private api: TerminalServices,) {
    this.opcionesEmpresa = [];
    this.opcionesVehiculos = [];
    this.inputEmpresas = new FormControl();
    this.inputVehiculos = new FormControl();
    this.selected = false;
    this.selectorform.valueChanges.subscribe(val => {
      console.log(this.selectorform.valid);
    })
  }

  ngOnInit(): void {
    this.obtieneCentrosLavado();
    this.obtieneEmpresas();
    this.obtieneVehiculos();
  }


  private obtieneCentrosLavado(): void {
    this.centrolavado = null;
    this.api.GetConfiguracion().pipe(first())
      .subscribe(configuracion => {
        this.configuracion = configuracion;
        if (configuracion.length > 0) {

          /// Asigna la categoría al precio
          // esta dato no viene deictamente del modelo por eso es necesario hacerlo manualmente aqui
          configuracion.forEach( c => {
            c.categorias.forEach(s => {
              s.servicios.forEach( p=> {
                p.precios.forEach( pp=> {
                  pp.categoriaId = p.categoriaId
                } );
              })
            } )
          });

          this.centrolavado = this.configuracion[0].centro.id;
          this.ValoresCentroLavado(this.centrolavado);
          this.MuestraServiciosCentro(this.configuracion[0].centro.id);
        }
      }, (err) => { }, () => { });
  }


  private ValoresCentroLavado(idcentro: string){
    this.selectorform.get(this.CENTROLAVADOID).setValue(idcentro);
    this.selectorform.get(this.CATEGORIAID).setValue(null);
    this.selectorform.get(this.SERVICIOID).setValue(null);
    this.selectorform.get(this.PRECIOID).setValue(null);
    this.selectorform.get(this.MONTO).setValue(null);
    this.selectorform.get(this.MONEDA).setValue(null);
  }

  private MuestraServiciosCentro(id: string) {
    this.servicio = null;
    this.servicios = [];
    this.precios = [];
    const temp: Servicio[] = [];
    const centro = this.configuracion.find(x => x.centro.id === id);
    if (centro !== null) {
      centro.categorias.forEach(c => {
        c.servicios.forEach(s => {
          temp.push(s);
        })
      });
    }
    this.servicios = temp;
    if (this.servicios.length > 0) {
      this.servicio = this.servicios[0].id;
      this.ValoresServicios(this.servicio);
      this.MuestraPrecios(this.servicio);
    }
  }

  private ValoresServicios(idservicio: string){
    this.selectorform.get(this.CATEGORIAID).setValue(null);
    this.selectorform.get(this.SERVICIOID).setValue(idservicio);
    this.selectorform.get(this.PRECIOID).setValue(null);
    this.selectorform.get(this.MONTO).setValue(null);
    this.selectorform.get(this.MONEDA).setValue(null);
  }

  private MuestraPrecios(servicioid: string) {
    this.selectorform.get('PrecioId').setValue(null);
    this.selectorform.get('CategoriaId').setValue(null);
    this.selectorform.get('Monto').setValue(null);
    this.precios = [];
    this.precio = null;
    this.selectorform.get('PrecioId').setValue(null);
    const s = this.servicios.find(x => x.id == servicioid);
    if (s != null) {

      this.precios = s.precios;
      
      if (this.precios && this.precios.length > 0) {
        this.precio = this.precios[0].id;
        this.ValoresPrecios(this.precios[0]);
      }
    }
  }

  private ValoresPrecios(p: Precio){
    this.selectorform.get(this.CATEGORIAID).setValue(p.categoriaId);
    this.selectorform.get(this.PRECIOID).setValue(p.id);
    this.selectorform.get(this.MONTO).setValue(p.monto);
    this.selectorform.get(this.MONEDA).setValue(p.moneda);
  }



public selectedChangeServicio(id:string){
  this.ValoresServicios(id);
  this.MuestraPrecios(id);
}

  private obtieneEmpresas(): void {
    this.empresasFiltradas$ = this.inputEmpresas.valueChanges
      .pipe(
        startWith(''),
        debounceTime(400),
        distinctUntilChanged(),
        switchMap(val => {
          if (this.selected) {
            this.selected = false;
            return this.selectedOption();
          } else {
            this.opcionesEmpresa = [];
            return this.filterEmpresas(val || '')
          }
        })
      );
  }

  filterEmpresas(val: string): Observable<ParOrdenado[]> {
    return this.api.GetEmpresas(val)
      .pipe(
        map(response => response.filter(option => {
          this.opcionesEmpresa.push(option);
          return option.texto.toLowerCase().indexOf(val.toLowerCase()) === 0
        }))
      )
  }


  // return un observable arreglo vacío, sirve para evitar un nuevo get al servidor
  selectedOption(): Observable<ParOrdenado[]> {
    const subject = new AsyncSubject<ParOrdenado[]>();
    subject.next([]);
    subject.complete();
    return subject;
  }

  // detecta el cambio de centro de lavao desde la UI
  selectedChangeCentro(id) {
    this.ValoresCentroLavado(id);
    this.MuestraServiciosCentro(id);
  }


  selectedChange(empresaid: any): void {
    this.selected = true;
    const empresa = this.opcionesEmpresa.find(x => x.texto === empresaid);
    if (empresa != null) {
      this.obtieneVehiculosEmpresa(empresa.id);
      this.selectorform.get(this.EMPRESATRANSPORTEID).setValue(empresa.id);
    }
  }

  selectedChangeCaja(vehiculoId: string) {
    const vehiculo = this.opcionesVehiculos.find(x=>x.texto = vehiculoId);
    if(vehiculo!=null){
      this.selectorform.get(this.TRACTORID).setValue(vehiculo.id);
    }
  } 

  private obtieneVehiculosEmpresa(id: string) {
    this.api.GetVehiculosEmpresa(id).pipe(first())
      .subscribe(vehiculos => {
        console.log(vehiculos);
        this.opcionesVehiculos = vehiculos;

      }, (err) => { }, () => { });
  }



  private filterVehiculos(value: string): ParOrdenado[] {
    const filterValue = value.toLowerCase();
    return this.opcionesVehiculos.filter(optionValue => optionValue.texto.toLowerCase().includes(filterValue));
  }

  private obtieneVehiculos(): void {
    this.vehiculosFiltrados$ = this.inputVehiculos.valueChanges
      .pipe(
        startWith(''),
        map(val => {
          return this.filterVehiculos(val || '')
        })
      );
  }

public selectedChangePrecio(id: string) {
  const p = this.precios.find(x=>x.id == id);
  if (p!=null ){
    this.ValoresPrecios(p);
  }
}

}

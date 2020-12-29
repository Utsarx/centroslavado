import { NavegarEmpresaComponent } from './navegar-empresa.component';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';



describe('BotonNavegarTablaComponent', () => {
  let component: NavegarEmpresaComponent;
  let fixture: ComponentFixture<NavegarEmpresaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavegarEmpresaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavegarEmpresaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavegarServicioComponent } from './navegar-servicio.component';

describe('NavegarServicioComponent', () => {
  let component: NavegarServicioComponent;
  let fixture: ComponentFixture<NavegarServicioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavegarServicioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavegarServicioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

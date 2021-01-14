import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoCajaComponent } from './dialogo-caja.component';

describe('DialogoCajaComponent', () => {
  let component: DialogoCajaComponent;
  let fixture: ComponentFixture<DialogoCajaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoCajaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoCajaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

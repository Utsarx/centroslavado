import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoEmpresaComponent } from './dialogo-empresa.component';

describe('DialogoEmpresaComponent', () => {
  let component: DialogoEmpresaComponent;
  let fixture: ComponentFixture<DialogoEmpresaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoEmpresaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoEmpresaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MostarUsuariosistemaComponent } from './mostar-usuariosistema.component';

describe('MostarUsuariosistemaComponent', () => {
  let component: MostarUsuariosistemaComponent;
  let fixture: ComponentFixture<MostarUsuariosistemaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MostarUsuariosistemaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MostarUsuariosistemaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

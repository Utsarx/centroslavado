import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorEmpleadoComponent } from './editor-empleado.component';

describe('EditorEmpleadoComponent', () => {
  let component: EditorEmpleadoComponent;
  let fixture: ComponentFixture<EditorEmpleadoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorEmpleadoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorEmpleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

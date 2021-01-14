import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorCajaComponent } from './editor-caja.component';

describe('EditorCajaComponent', () => {
  let component: EditorCajaComponent;
  let fixture: ComponentFixture<EditorCajaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorCajaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorCajaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

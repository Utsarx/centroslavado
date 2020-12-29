import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorEmpresaComponent } from './editor-empresa.component';

describe('EditorEmpresaComponent', () => {
  let component: EditorEmpresaComponent;
  let fixture: ComponentFixture<EditorEmpresaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorEmpresaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorEmpresaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

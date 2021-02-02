import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorCategoriaComponent } from './editor-categoria.component';

describe('EditorCategoriaComponent', () => {
  let component: EditorCategoriaComponent;
  let fixture: ComponentFixture<EditorCategoriaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorCategoriaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

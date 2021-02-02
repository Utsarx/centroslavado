import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorCentroComponent } from './editor-centro.component';

describe('EditorCentroComponent', () => {
  let component: EditorCentroComponent;
  let fixture: ComponentFixture<EditorCentroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorCentroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorCentroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

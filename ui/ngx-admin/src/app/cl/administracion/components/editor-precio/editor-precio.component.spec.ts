import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorPrecioComponent } from './editor-precio.component';

describe('EditorPrecioComponent', () => {
  let component: EditorPrecioComponent;
  let fixture: ComponentFixture<EditorPrecioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorPrecioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorPrecioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

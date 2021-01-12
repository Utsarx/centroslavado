import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorTractorComponent } from './editor-tractor.component';

describe('EditorTractorComponent', () => {
  let component: EditorTractorComponent;
  let fixture: ComponentFixture<EditorTractorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorTractorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorTractorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

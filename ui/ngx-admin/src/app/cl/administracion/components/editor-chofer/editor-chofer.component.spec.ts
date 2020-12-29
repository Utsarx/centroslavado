import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditorChoferComponent } from './editor-chofer.component';

describe('EditorChoferComponent', () => {
  let component: EditorChoferComponent;
  let fixture: ComponentFixture<EditorChoferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditorChoferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditorChoferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

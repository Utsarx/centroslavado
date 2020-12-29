import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoChoferComponent } from './dialogo-chofer.component';

describe('DialogoChoferComponent', () => {
  let component: DialogoChoferComponent;
  let fixture: ComponentFixture<DialogoChoferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoChoferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoChoferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoTractorComponent } from './dialogo-tractor.component';

describe('DialogoTractorComponent', () => {
  let component: DialogoTractorComponent;
  let fixture: ComponentFixture<DialogoTractorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoTractorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoTractorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

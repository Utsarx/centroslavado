import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoCentroComponent } from './dialogo-centro.component';

describe('DialogoCentroComponent', () => {
  let component: DialogoCentroComponent;
  let fixture: ComponentFixture<DialogoCentroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoCentroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoCentroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

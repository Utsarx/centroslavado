import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoPrecioComponent } from './dialogo-precio.component';

describe('DialogoPrecioComponent', () => {
  let component: DialogoPrecioComponent;
  let fixture: ComponentFixture<DialogoPrecioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoPrecioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoPrecioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

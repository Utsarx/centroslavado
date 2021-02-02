import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavegarCentroComponent } from './navegar-centro.component';

describe('NavegarCentroComponent', () => {
  let component: NavegarCentroComponent;
  let fixture: ComponentFixture<NavegarCentroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavegarCentroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavegarCentroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

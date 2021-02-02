import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogoCategoriaComponent } from './dialogo-categoria.component';

describe('DialogoCategoriaComponent', () => {
  let component: DialogoCategoriaComponent;
  let fixture: ComponentFixture<DialogoCategoriaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogoCategoriaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogoCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

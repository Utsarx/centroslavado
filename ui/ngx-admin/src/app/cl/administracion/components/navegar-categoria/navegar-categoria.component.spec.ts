import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavegarCategoriaComponent } from './navegar-categoria.component';

describe('NavegarCategoriaComponent', () => {
  let component: NavegarCategoriaComponent;
  let fixture: ComponentFixture<NavegarCategoriaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavegarCategoriaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavegarCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

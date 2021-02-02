import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPreciosComponent } from './admin-precios.component';

describe('AdminPreciosComponent', () => {
  let component: AdminPreciosComponent;
  let fixture: ComponentFixture<AdminPreciosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminPreciosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminPreciosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

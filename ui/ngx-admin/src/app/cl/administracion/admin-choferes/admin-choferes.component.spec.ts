import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminChoferesComponent } from './admin-choferes.component';

describe('AdminChoferesComponent', () => {
  let component: AdminChoferesComponent;
  let fixture: ComponentFixture<AdminChoferesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminChoferesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminChoferesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

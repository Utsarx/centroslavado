import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminTractoresComponent } from './admin-tractores.component';

describe('AdminTractoresComponent', () => {
  let component: AdminTractoresComponent;
  let fixture: ComponentFixture<AdminTractoresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminTractoresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminTractoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

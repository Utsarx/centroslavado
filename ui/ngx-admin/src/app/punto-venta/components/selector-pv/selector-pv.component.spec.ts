import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectorPvComponent } from './selector-pv.component';

describe('SelectorPvComponent', () => {
  let component: SelectorPvComponent;
  let fixture: ComponentFixture<SelectorPvComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectorPvComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectorPvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

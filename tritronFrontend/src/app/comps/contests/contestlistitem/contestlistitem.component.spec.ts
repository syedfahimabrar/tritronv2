import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContestlistitemComponent } from './contestlistitem.component';

describe('ContestlistitemComponent', () => {
  let component: ContestlistitemComponent;
  let fixture: ComponentFixture<ContestlistitemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContestlistitemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContestlistitemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

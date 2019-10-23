import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RunningcontestComponent } from './runningcontest.component';

describe('RunningcontestComponent', () => {
  let component: RunningcontestComponent;
  let fixture: ComponentFixture<RunningcontestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RunningcontestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RunningcontestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

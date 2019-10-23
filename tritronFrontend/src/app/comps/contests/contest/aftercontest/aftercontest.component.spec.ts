import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AftercontestComponent } from './aftercontest.component';

describe('AftercontestComponent', () => {
  let component: AftercontestComponent;
  let fixture: ComponentFixture<AftercontestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AftercontestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AftercontestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

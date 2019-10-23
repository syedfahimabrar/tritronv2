import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BeforecontestComponent } from './beforecontest.component';

describe('BeforecontestComponent', () => {
  let component: BeforecontestComponent;
  let fixture: ComponentFixture<BeforecontestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BeforecontestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BeforecontestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

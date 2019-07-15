import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateproblemComponent } from './createproblem.component';

describe('CreateproblemComponent', () => {
  let component: CreateproblemComponent;
  let fixture: ComponentFixture<CreateproblemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateproblemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateproblemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

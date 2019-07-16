import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditproblemComponent } from './editproblem.component';

describe('EditproblemComponent', () => {
  let component: EditproblemComponent;
  let fixture: ComponentFixture<EditproblemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditproblemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditproblemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

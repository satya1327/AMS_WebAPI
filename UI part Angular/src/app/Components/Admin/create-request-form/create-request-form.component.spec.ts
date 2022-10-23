import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateRequestFormComponent } from './create-request-form.component';

describe('CreateRequestFormComponent', () => {
  let component: CreateRequestFormComponent;
  let fixture: ComponentFixture<CreateRequestFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateRequestFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

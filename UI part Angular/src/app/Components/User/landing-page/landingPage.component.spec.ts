import { ComponentFixture, TestBed } from '@angular/core/testing';

import { landingPageComponent } from './landingPage.component';

describe('landingPageComponent', () => {
  let component: landingPageComponent;
  let fixture: ComponentFixture<landingPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ landingPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(landingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

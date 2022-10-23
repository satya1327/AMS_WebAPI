import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LatestRequestComponent } from './latest-request.component';

describe('LatestRequestComponent', () => {
  let component: LatestRequestComponent;
  let fixture: ComponentFixture<LatestRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LatestRequestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LatestRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

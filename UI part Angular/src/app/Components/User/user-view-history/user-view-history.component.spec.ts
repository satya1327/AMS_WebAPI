import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserViewHistoryComponent } from './user-view-history.component';

describe('UserViewHistoryComponent', () => {
  let component: UserViewHistoryComponent;
  let fixture: ComponentFixture<UserViewHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserViewHistoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserViewHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

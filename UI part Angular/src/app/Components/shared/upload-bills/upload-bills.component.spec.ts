import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadBillsComponent } from './upload-bills.component';

describe('UploadBillsComponent', () => {
  let component: UploadBillsComponent;
  let fixture: ComponentFixture<UploadBillsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UploadBillsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UploadBillsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

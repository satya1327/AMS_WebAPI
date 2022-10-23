import { TestBed } from '@angular/core/testing';

import { RequestServicesService } from './request-services.service';

describe('RequestServicesService', () => {
  let service: RequestServicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequestServicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

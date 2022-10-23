import { TestBed } from '@angular/core/testing';

import { RequestStatusServiceService } from './request-status-service.service';

describe('RequestStatusServiceService', () => {
  let service: RequestStatusServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequestStatusServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

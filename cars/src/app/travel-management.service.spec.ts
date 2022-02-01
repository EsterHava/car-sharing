import { TestBed } from '@angular/core/testing';

import { TravelManagementService } from './travel-management.service';

describe('TravelManagementService', () => {
  let service: TravelManagementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TravelManagementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

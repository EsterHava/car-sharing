import { TestBed } from '@angular/core/testing';

import { UserManagmentServiceService } from './user-managment-service.service';

describe('UserManagmentServiceService', () => {
  let service: UserManagmentServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserManagmentServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

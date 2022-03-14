import { TestBed } from '@angular/core/testing';

import { JoinManagmentService } from './join-managment.service';

describe('JoinManagmentService', () => {
  let service: JoinManagmentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JoinManagmentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

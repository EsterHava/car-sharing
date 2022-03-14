import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableForTravelerComponent } from './table-for-traveler.component';

describe('TableForTravelerComponent', () => {
  let component: TableForTravelerComponent;
  let fixture: ComponentFixture<TableForTravelerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableForTravelerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableForTravelerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

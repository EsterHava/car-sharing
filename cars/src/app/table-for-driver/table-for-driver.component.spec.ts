import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TableForDriverComponent } from './table-for-driver.component';

describe('TableForDriverComponent', () => {
  let component: TableForDriverComponent;
  let fixture: ComponentFixture<TableForDriverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TableForDriverComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TableForDriverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

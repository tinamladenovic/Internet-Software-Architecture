import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyDatesComponent } from './company-dates.component';

describe('CompanyDatesComponent', () => {
  let component: CompanyDatesComponent;
  let fixture: ComponentFixture<CompanyDatesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyDatesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompanyDatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

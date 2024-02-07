import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompanyEquipmentComponent } from './company-equipment.component';

describe('CompanyEquipmentComponent', () => {
  let component: CompanyEquipmentComponent;
  let fixture: ComponentFixture<CompanyEquipmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CompanyEquipmentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CompanyEquipmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

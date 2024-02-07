import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentPickupComponent } from './equipment-pickup.component';

describe('EquipmentPickupComponent', () => {
  let component: EquipmentPickupComponent;
  let fixture: ComponentFixture<EquipmentPickupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentPickupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EquipmentPickupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

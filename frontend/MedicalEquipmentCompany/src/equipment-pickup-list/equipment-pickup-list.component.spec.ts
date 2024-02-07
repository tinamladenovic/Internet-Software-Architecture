import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipmentPickupListComponent } from './equipment-pickup-list.component';

describe('EquipmentPickupListComponent', () => {
  let component: EquipmentPickupListComponent;
  let fixture: ComponentFixture<EquipmentPickupListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EquipmentPickupListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EquipmentPickupListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

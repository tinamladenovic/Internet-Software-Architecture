import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppService } from '../app.service';
import { EquipmentPickup } from '../model/equipment-pickup.model';
import { PagedResults } from '../model/page-results.model';

@Component({
  selector: 'app-equipment-pickup-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './equipment-pickup-list.component.html',
  styleUrl: './equipment-pickup-list.component.css'
})
export class EquipmentPickupListComponent implements OnInit {

  equipmentPickups: EquipmentPickup[]=[];
  constructor(private appService: AppService){}

  ngOnInit(): void {
    this.getEquipmentPickups();
  }

  getEquipmentPickups(): void {
    this.appService.getEquipmentPickups().subscribe({
      next: (result: PagedResults<EquipmentPickup>) => {
        this.equipmentPickups = result.results;
      },
      error: () => {
        // Handle error if needed
        console.error('Error fetching equipment reservations');
      }
    });

}
}

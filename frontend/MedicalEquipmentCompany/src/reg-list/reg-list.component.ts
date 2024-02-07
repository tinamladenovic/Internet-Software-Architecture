import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EquipmentReservation } from '../model/equipment-reservation.model';
import { AppService } from '../app.service';
import { PagedResults } from '../model/page-results.model';
import { Equipment } from '../model/equipment.model';

enum Status {
  OnWait,
  Completed,
  Expired,
  Canceled
}

@Component({
  selector: 'app-reg-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reg-list.component.html',
  styleUrl: './reg-list.component.css'
})
export class RegListComponent implements OnInit {

  reservations: EquipmentReservation[] = [];

  constructor(private appService: AppService) {
  }

  ngOnInit(): void {
    this.getEquipmentReservations();
  }

  getEquipmentReservations(): void {
    this.appService.getEquipmentReservations().subscribe((equipment:PagedResults<EquipmentReservation>)=>{
      this.reservations = equipment.results;
    })
  }

  
  updateEquipmentReservation(equipment: EquipmentReservation): void {
    // Ako želite promeniti reservationStatus u "Completed"
    equipment.reservationStatus = Status.Completed;
  
    this.appService.updateEquipmentReservations(equipment).subscribe(updatedEquipment => {
      // Find the index of the updated reservation in the array
      const index = this.reservations.findIndex(reservation => reservation.id === updatedEquipment.id);
  
      // Update the reservation in the array
      if (index !== -1) {
        this.reservations[index] = updatedEquipment;
      }
  
      // Log the updated array for verification
      console.log('Updated Reservations Array:', this.reservations);
  
      // Dodajte dodatne operacije prema potrebi...
    }, error => {
      console.error('Error updating equipment reservation:', error);
    });
  } 


  
  
  getStatusText(status: Status): string {
    switch (status) {
      case Status.OnWait:
        return 'On Wait';
      case Status.Completed:
        return 'Completed';
      case Status.Expired:
        return 'Expired';
      case Status.Canceled:
        return 'Canceled';
      default:
        return 'Unknown';
    }
  }

  
}

import { Component, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { User } from '../model/user.model';
import { EquipmentReservation } from '../model/equipment-reservation.model';
import { AppService } from '../app.service';
import { ActivatedRoute, Router } from '@angular/router';
import { PagedResults } from '../model/page-results.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reservations-user',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reservations-user.component.html',
  styleUrl: './reservations-user.component.css'
})
export class ReservationsUserComponent {


  public user!: User;
  public reservations: EquipmentReservation[] = [];

  constructor(private toastr: ToastrService,private service:AppService, private router : Router, private route : ActivatedRoute){
  }

  ngOnInit(changes: SimpleChanges): void {
    setTimeout(()=>{
      this.service.user$.subscribe((user) => {
        this.user = user;
        this.getReservations();
      });
    },100)
  }
  
  getReservations() {
    this.service.getReservationsByUser(this.user).subscribe((reservation:PagedResults<EquipmentReservation>)=>{
      this.reservations = reservation.results;
    
  })
 }
  deleteReservation(reservation: EquipmentReservation):void {
  this.service.deleteReservation(reservation.id!).subscribe({
    next: () => {
      this.toastr.success('Reservation cancel succesfully.', 'Reservation cancel');
      this.getReservations();
    },
  })
}
}

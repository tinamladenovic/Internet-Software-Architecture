import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompanyProfile } from '../model/company-profile.model';
import { EquipmentReservation, Status } from '../model/equipment-reservation.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AppService } from '../app.service';
import { Equipment } from '../model/equipment.model';
import { PagedResults } from '../model/page-results.model';
import { EquipmentPickup } from '../model/equipment-pickup.model';
import { CompanyProfileService } from '../company-profile.service';
import { User } from '../model/user.model';
import { FormsModule, NgModel } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-company-dates',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './company-dates.component.html',
  styleUrl: './company-dates.component.css'
})
export class CompanyDatesComponent  {
  @Input() company !: CompanyProfile ;
  public companyId !: number;
  public equipmentId !: number;
  public equipment !: Equipment;
  public dates: EquipmentPickup[] = [];
  public user!: User;
  count: number | undefined;
  selectedReservation!: EquipmentPickup;
  isCountValid: boolean = false;
  countValid: boolean = true;
  constructor(private toastr: ToastrService, private service:AppService, private companyService: CompanyProfileService, private router : Router, private route : ActivatedRoute){
  }

  ngOnInit(changes: SimpleChanges): void {
    setTimeout(()=>{
      this.service.user$.subscribe((user) => {
        this.user = user;
      });
    },100)
    this.route.params.subscribe(params => {
      const id = +params['id'];
      const eId = +params['eId'];
      if (!isNaN(id)) {
        this.companyId = id; 
        this.equipmentId = eId;
        this.companyService.getCompanyProfile(id).subscribe((value:CompanyProfile)=> {
          this.company = value;
          this.getDates();
        })
        this.service.getEquimpent(this.equipmentId).subscribe((value : Equipment)=> {
          this.equipment = value;
        });
      } else {
    } } )
  }

  getDates(){
    this.service.getEquipmentPickupsByCompany(this.company).subscribe((equipment:PagedResults<EquipmentPickup>)=>{
      this.dates = equipment.results;
    })
  }
  confirmReservation(date : EquipmentPickup): void {
    this.selectedReservation = date
    this.selectedReservation.dateAndTime = new Date(date.dateAndTime);
    this.count = undefined;
  }
  validateCount(): void {
    this.isCountValid = this.count !== undefined && this.count > 0;
    this.countValid = true;
  }

  makeReservation(): void {
    if (this.isCountValid) {
      this.service.getEquipmentCount(this.equipmentId, this.count!).subscribe((value : boolean)=> {
        this.countValid = value;
          if(value!){
            const equipmentReservation: EquipmentReservation = {
              userId: this.user.id,
              companyId: this.companyId || 0,
              reservationDate: new Date(), 
              reservationStatus: Status.OnWait, 
              reservedEquipment: [this.equipmentId],
              equipmentCount: [this.count!],
              equipmentPickup: this.selectedReservation.id || 0, 
            };
      
            this.service.createReservation(equipmentReservation).subscribe({
              next: () => {
                this.count = undefined;
                this.isCountValid = false;
                this.toastr.success('Reservation success.', 'Reservation');
              },
              error: () => {
                this.toastr.error('Reservation faild.', 'Reservation');
              }
            });
            this.router.navigate(['']);
          }
        }
      
      )
    } 
  }

}

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

@Component({
  selector: 'app-company-dates',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './company-dates.component.html',
  styleUrl: './company-dates.component.css'
})
export class CompanyDatesComponent  {
  @Input() company !: CompanyProfile ;
  public companyId !: number;
  public equipmentId !: number;
  public dates: EquipmentPickup[] = [];
  public user!: User;
  constructor(private service:AppService, private companyService: CompanyProfileService, private router : Router, private route : ActivatedRoute){
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
      } else {
    } } )
  }

  getDates(){
    this.service.getEquipmentPickupsByCompany(this.company).subscribe((equipment:PagedResults<EquipmentPickup>)=>{
      this.dates = equipment.results;
    })
  }

  makeReservation(date : EquipmentPickup) : void {
      const equipmentReservation: EquipmentReservation = {
      userId: this.user.id,
      companyId: this.companyId || 0,
      reservationDate: new Date(), 
      reservationStatus: Status.OnWait, 
      reservedEquipment: [this.equipmentId],
      equipmentCount: [1],
      equipmentPickup: date.id || 0, 
    };
    this.service.createReservation(equipmentReservation).subscribe({
      next: () => {
        this.router.navigate(['']);
      }
    })

  }

}

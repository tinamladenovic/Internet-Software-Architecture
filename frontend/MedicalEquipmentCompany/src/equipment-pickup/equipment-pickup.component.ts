import { Component, OnInit } from '@angular/core';
import { CommonModule, Time } from '@angular/common';
import { AppService } from '../app.service';
import { EquipmentPickup } from '../model/equipment-pickup.model';
import { CompanyAdministratorProfile } from '../model/company-administrator-profile.model';
import { PagedResults } from '../model/page-results.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyProfile } from '../model/company-profile.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-equipment-pickup',
  standalone: true,
  imports: [CommonModule, EquipmentPickupComponent,FormsModule],
  templateUrl: './equipment-pickup.component.html',
  styleUrl: './equipment-pickup.component.css'
})

export class EquipmentPickupComponent implements OnInit {
  equipmentPickups: EquipmentPickup[] = [];
  pickupDate!: Date; 
  pickupTime: string = '';
  durationHours: number = 0;
  adminName: string = '';
  adminSurname: string = '';
  company!: CompanyProfile;
  admins!: CompanyAdministratorProfile[];
  selectedAdmin:any;
  
  constructor(private appService: AppService,private activeRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.activeRoute.params.subscribe(params => {
      if(params['id']) {
          this.appService.getCompany(params['id']).subscribe((company:CompanyProfile)=>{
            this.company = company
            let admins:CompanyAdministratorProfile[] = []
            for (let i = 0; i < this.company.administratorIds.length; i++) {
              const adminId = this.company.administratorIds[i];
              this.appService.getCompanyAdmins(adminId).subscribe((admin:CompanyAdministratorProfile)=>{
                admins.push(admin)
              })
            }
            this.admins = admins;
          })
      }
  })
  }



  submitForm(): void {
    let zz = new Date(this.pickupDate + 'T' + this.pickupTime)
    let date = new Date(zz.getFullYear(),zz.getMonth(),zz.getDay(),zz.getHours(),zz.getMinutes(),zz.getSeconds(),zz.getMilliseconds())
    var isoDate = date.toJSON() // eg: '2022-11-18T13:56:09.697Z'
    isoDate = isoDate.slice(0, -1);
    isoDate += '+02'
    isoDate = isoDate.replace('T',' ')
    console.log(isoDate)
    const newEquipmentPickup: EquipmentPickup = {
      dateAndTime: new Date(isoDate), 
      duration: this.durationHours,
      isReserved: false, 
      administratorId: parseInt(this.selectedAdmin),
      companyId: this.company.id
    };
    console.log(newEquipmentPickup)
    this.appService.addEquipmentPickup(newEquipmentPickup).subscribe(
      (result: any) => {
        console.log('Successfully added equipment pickup:', result);
      }
    );
  }
}
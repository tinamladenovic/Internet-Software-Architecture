import { Component, OnInit, ViewChild } from '@angular/core';
import { CompanyProfile } from '../model/company-profile.model';
import { CompanyProfileService } from '../company-profile.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { User } from '../model/user.model';
import { AppService } from '../app.service';
import { AuthGuard } from '../app/auth.guard';
import { CompanyEquipmentComponent } from "../company-equipment/company-equipment.component";
import { EquipmentPickup } from '../model/equipment-pickup.model';
import { PagedResults } from '../model/page-results.model';
import { CompanyWorkingHours } from '../model/company-working-hours.model';
import { MatDatepicker, MatDatepickerControl, MatDatepickerInput, MatDatepickerModule, MatDatepickerPanel } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@Component({
    selector: 'app-company-profile',
    standalone: true,
    templateUrl: './company-profile.component.html',
    styleUrls: ['./company-profile.component.css'],
    providers: [CompanyProfileService,MatDatepicker],
    imports: [CommonModule, RouterModule, CompanyEquipmentComponent,MatDatepickerModule,MatNativeDateModule]
})
export class CompanyProfileComponent implements OnInit {
  companyProfile!: CompanyProfile;
  companyId!: number | 0;
  user: User | undefined;
  equipPickups!:EquipmentPickup[];
  finishLoading:Boolean = false;
  workingHours!:CompanyWorkingHours[];
  myDatepicker!:any;
  daysdict = ['Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday']

  constructor(private service: CompanyProfileService, private appService:AppService, private route : ActivatedRoute) { }

  ngOnInit(): void {
    setTimeout(()=>{
      this.appService.user$.subscribe((user) => {
        this.user = user;
        console.log(this.user)
      });
    },10000)
    this.route.params.subscribe(params => {
      const id = +params['id']; 
      if (!isNaN(id)) {
        this.companyId = id; 
        this.getCompanyProfile();
      } else {
      }
    });
    this.appService.getWorkingHours().subscribe((data)=>{
      this.workingHours = data.results
    })
  }
/*   _openCalendar() {
    setTimeout(()=>this.picker.open());
   } */
  getHours(date:string){
    let newDate = new Date(date);
    if (newDate.getHours() == 0) {
      return '00:00'
    }
    return (newDate.getHours()+':00')
  }

  onReservePickup(pickup:EquipmentPickup){
    pickup.isReserved = true;
    this.appService.updateEquipmentPickup(pickup).subscribe((data)=>{
      console.log('Successful update!')
      alert('Successfuly reserved!')
    })
  }

  getCompanyProfile(): void {
    this.service.getCompanyProfile(this.companyId).subscribe({
      next: (result: CompanyProfile) => {
        this.companyProfile = result;
        this.appService.getEquipmentPickup().subscribe((equipPickup:PagedResults<EquipmentPickup>)=>{
          this.equipPickups = equipPickup.results.filter((equipPickup)=>{
            if (equipPickup.companyId == this.companyId) {
              equipPickup.dateAndTime = new Date(equipPickup.dateAndTime)
              return true;
            }
            else {
              return false
            }
          })
          this.finishLoading = true;
        })
      },
      error: () => {
      }
    })
  }
}

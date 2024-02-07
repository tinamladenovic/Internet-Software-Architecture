import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompanyProfile } from '../model/company-profile.model';
import { CompanyAdministratorProfile } from '../model/company-administrator-profile.model';
import { AppService } from '../app.service';
import { ActivatedRoute } from '@angular/router';
import { CompanyProfileService } from '../company-profile.service';


@Component({
  selector: 'app-statistic',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './statistic.component.html',
  styleUrl: './statistic.component.css'
})
export class StatisticComponent implements OnInit {

  companyProfile!: CompanyProfile;
  pickupDate!: Date; 
  pickupTime: string = '';
  durationHours: number = 0;
  adminName: string = '';
  adminSurname: string = '';
  company!: CompanyProfile;
  admins!: CompanyAdministratorProfile[];
  selectedAdmin:any;

  constructor(private appService: AppService,private activeRoute: ActivatedRoute, private service: CompanyProfileService) {}

  ngOnInit(): void {
    
  }

}

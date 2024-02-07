import { Component, OnInit } from '@angular/core';
import { CompanyAdministratorProfile } from '../model/company-administrator-profile.model';
import { AppService } from '../app.service';
import { User } from '../model/user.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-profile',
  imports: [CommonModule],
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  standalone: true
})
export class ProfileComponent implements OnInit {
  admins: CompanyAdministratorProfile | undefined;
  loggedInUserId: number | undefined = 0; // Postavite inicijalnu vrednost prema potrebi

  constructor(private appService: AppService) {}

  ngOnInit(): void {
    
    this.getLoggedInUser();
 
  }

  getLoggedInUser(): void {
    this.appService.getLoggedInUser().subscribe({
      next: (result: User) => {
        this.loggedInUserId = result.id; 
        if (this.loggedInUserId !== undefined) {
          this.getCompanyAdminProfile(this.loggedInUserId);
        } else {
          console.error('Error: loggedInUserId is undefined');
        }
      },
      error: () => {
        console.error('Error fetching current company administrator profile');
      }
    });
  }
  
  
  getCompanyAdminProfile(userId: number): void {
    this.appService.getCompanyAdmins(userId).subscribe({
      next: (result: CompanyAdministratorProfile) => {
        this.admins = result;
      },
      error: () => {
        console.error('Error fetching company administrator profile');
      }
    });
  }
}

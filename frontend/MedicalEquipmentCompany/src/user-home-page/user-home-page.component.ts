import { Component, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReservationsUserComponent } from "../reservations-user/reservations-user.component";
import { User } from '../model/user.model';
import { AppService } from '../app.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

@Component({
    selector: 'app-user-home-page',
    standalone: true,
    templateUrl: './user-home-page.component.html',
    styleUrl: './user-home-page.component.css',
    imports: [CommonModule, ReservationsUserComponent],
    providers:[] 
})
export class UserHomePageComponent {

    public user!: User;
  
    constructor(private service:AppService, private router : Router, private route : ActivatedRoute){
    }
    ngOnInit(changes: SimpleChanges): void {
        setTimeout(()=>{
          this.service.user$.subscribe((user) => {
            this.user = user;
            console.log("Home page: " + this.user.username);
          });
        },100)

      }

}

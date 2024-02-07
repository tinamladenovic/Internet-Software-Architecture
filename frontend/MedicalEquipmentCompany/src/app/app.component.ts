import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from "../navbar/navbar.component";
import { FooterComponent } from '../footer/footer.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { AppService } from '../app.service';
import { FormsModule } from '@angular/forms';
import { AuthGuard } from './auth.guard';
import { TokenStorage } from '../jwt/token.service';
import {MatDatepicker, MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';


@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    imports: [CommonModule, RouterOutlet, NavbarComponent, FooterComponent, HttpClientModule,FormsModule,MatDatepickerModule,MatNativeDateModule],
    providers: [ HttpClientModule, AppService,MatDatepicker]
})
export class AppComponent implements OnInit{
  constructor(private httpClient: HttpClient,private service:AppService,private router:Router,private tokenStorage:TokenStorage) { }

  ngOnInit(): void {
    const accessToken = this.tokenStorage.getAccessToken()
    if (accessToken !== null) {
      this.service.setUser();
    }
  }
  title = 'MedicalEquipmentCompany';

}

import { Routes, mapToCanActivate } from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { CompanySearchComponent } from '../company-search/company-search.component';
import { EquipmentSearchComponent } from '../equipment-search/equipment-search.component';
import { CompanyProfileComponent } from '../company-profile/company-profile.component';
import { AuthGuard } from './auth.guard';
import { CompanyDatesComponent } from '../company-dates/company-dates.component';
import { EquipmentPickupComponent } from '../equipment-pickup/equipment-pickup.component';
import { UserHomePageComponent } from '../user-home-page/user-home-page.component';
import { LocationTrackerComponent } from './location-tracker/location-tracker.component';


export const routes: Routes = [
    {path: '', component: CompanySearchComponent},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'company', component: CompanySearchComponent},
    {path: 'equipment', component: EquipmentSearchComponent},
    {path: 'companyProfile/:id', component: CompanyProfileComponent, canActivate:[AuthGuard]},
    {path: 'equipmentPickup/:id', component: EquipmentPickupComponent},
    {path: 'companyDates/:id/:eId', component: CompanyDatesComponent, canActivate:[AuthGuard]},
    {path: 'UserHome', component: UserHomePageComponent, canActivate:[AuthGuard]},
    {path: 'simulator', component: LocationTrackerComponent, canActivate:[AuthGuard]},
];

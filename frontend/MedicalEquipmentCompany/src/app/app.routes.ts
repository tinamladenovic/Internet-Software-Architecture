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
import { CompanyadminHomepageComponent } from '../companyadmin-homepage/companyadmin-homepage.component';
import { RegListComponent } from '../reg-list/reg-list.component';
import { CompanyEquipmentComponent } from '../company-equipment/company-equipment.component';
import { WorkingCalendarComponent } from '../working-calendar/working-calendar.component';
import { EquipmentPickupListComponent } from '../equipment-pickup-list/equipment-pickup-list.component';
import { ProfileComponent } from '../profile/profile.component';
import { NewReservationComponent } from '../new-reservation/new-reservation.component';
import { StatisticComponent } from '../statistic/statistic.component';



export const routes: Routes = [
    {path: '', component: CompanySearchComponent},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'company', component: CompanySearchComponent},
    {path: 'equipment', component: EquipmentSearchComponent},
    {path: 'companyProfile/:id', component: CompanyProfileComponent, canActivate:[AuthGuard]},
    {path: 'equipmentPickup/:id', component: EquipmentPickupComponent},
    {path: 'equipmentPickup', component: EquipmentPickupComponent},
    {path: 'companyDates/:id/:eId', component: CompanyDatesComponent, canActivate:[AuthGuard]},
    {path: 'companyAdminProfile', component: CompanyadminHomepageComponent},
    {path: 'equipmentReservations', component: RegListComponent},
    {path: 'companyEquipment', component: CompanyEquipmentComponent},
    {path: 'workingCalendar', component: WorkingCalendarComponent},
    {path: 'equipmentPickupList', component: EquipmentPickupListComponent},
    {path: 'profile', component: ProfileComponent},
    {path: 'newReservation', component: NewReservationComponent},
    {path: 'statistic:id', component: StatisticComponent}
];

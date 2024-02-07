import { Injectable } from '@angular/core';
import { Registration } from './model/registration.model';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { TokenStorage } from './jwt/token.service';
import { User } from './model/user.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticationResponse } from './model/authenticationResponse.model';
import { environment } from './env/enviroment';
import { CompanyProfile } from './model/company-profile.model';
import { PagedResults } from './model/page-results.model';
import {
  SearchInputsComp,
  SearchInputsEquip,
} from './model/searchInputs.model';
import { Equipment } from './model/equipment.model';
import { Login } from './model/login.model';
import { EquipmentPickup } from './model/equipment-pickup.model';
import { EquipmentReservation } from './model/equipment-reservation.model';
import { CompanyAdministratorProfile } from './model/company-administrator-profile.model';
import { CompanyWorkingHours } from './model/company-working-hours.model';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  user$ = new BehaviorSubject<User>({ username: '', id: 0, role: '' });

  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorage,
    private router: Router
  ) {}

  login(login: Login): Observable<AuthenticationResponse> {
    return this.http
      .post<AuthenticationResponse>(environment.apiHost + 'users/login', login)
      .pipe(
        tap((authenticationResponse) => {
          this.tokenStorage.saveAccessToken(authenticationResponse.accessToken);
          this.setUser();
        })
      );
  }

  register(registration: Registration): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(
      environment.apiHost + 'users',
      registration
    );
  }

  checkIfUserExists(): void {
    const accessToken = this.tokenStorage.getAccessToken();
    if (accessToken == null) {
      return;
    }
    this.setUser();
  }

  setUser(): void {
    const jwtHelperService = new JwtHelperService();
    const accessToken = this.tokenStorage.getAccessToken() || '';
    const user: User = {
      id: +jwtHelperService.decodeToken(accessToken).id,
      username: jwtHelperService.decodeToken(accessToken).username,
      role: jwtHelperService.decodeToken(accessToken)[
        'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
      ],
    };
    this.user$.next(user);
  }

  logout(): void {
    this.router.navigate(['/']).then((_) => {
      this.tokenStorage.clear();
      this.user$.next({ username: '', id: 0, role: '' });
    });
  }

  getCompanies(): Observable<PagedResults<CompanyProfile>> {
    return this.http.get<PagedResults<CompanyProfile>>(
      environment.apiHost + 'company'
    );
  }
  searchCompanies(
    searchInput: SearchInputsComp
  ): Observable<PagedResults<CompanyProfile>> {
    return this.http.post<PagedResults<CompanyProfile>>(
      environment.apiHost + 'company/search',
      searchInput
    );
  }
  getEquipment(): Observable<PagedResults<Equipment>> {
    return this.http.get<PagedResults<Equipment>>(
      environment.apiHost + 'equipment'
    );
  }
  getEquipmentByCompany(
    company: CompanyProfile
  ): Observable<PagedResults<Equipment>> {
    return this.http.post<PagedResults<Equipment>>(
      environment.apiHost + 'equipment/search/company',
      company
    );
  }

  searchEquipment(
    searchInput: SearchInputsEquip
  ): Observable<PagedResults<Equipment>> {
    return this.http.post<PagedResults<Equipment>>(
      environment.apiHost + 'equipment/search',
      searchInput
    );
  }

  getEquipmentPickup(): Observable<PagedResults<EquipmentPickup>> {
    return this.http.get<PagedResults<EquipmentPickup>>(
      environment.apiHost + 'equipmentPickup'
    );
  }
  updateEquipmentPickup(equipmentPickup:EquipmentPickup): Observable<PagedResults<EquipmentPickup>> {
    return this.http.put<PagedResults<EquipmentPickup>>(
      environment.apiHost + 'equipmentPickup'
    ,equipmentPickup);
  }

  addEquipmentPickup(
    equipmentPickup: EquipmentPickup
  ): Observable<EquipmentPickup> {
    return this.http.post<EquipmentPickup>(
      environment.apiHost + 'equipmentPickup',
      equipmentPickup
    );
  }
  getCompanyAdmins(id:number): Observable<CompanyAdministratorProfile> {
    return this.http.get<CompanyAdministratorProfile>(
      environment.apiHost + 'companyAdministratorProfile/' + id
    );
  }
  getCompany(id:number): Observable<CompanyProfile> {
    return this.http.get<CompanyProfile>(
      environment.apiHost + 'company/' + id
    );
  }
  getWorkingHours(){
    return this.http.get<PagedResults<CompanyWorkingHours>>(
      environment.apiHost + 'companyWorkingHours'
    );
  }
  getEquipmentPickupsByCompany(company: CompanyProfile): Observable<PagedResults<EquipmentPickup>> {
    return this.http.post<PagedResults<EquipmentPickup>>(environment.apiHost + 'equipmentPickup/search/dates',company)
  }
  createReservation(reservation: EquipmentReservation) : Observable<EquipmentReservation>{
    return this.http.post<EquipmentReservation>(environment.apiHost + 'equipmentReservation' , reservation)
  }

  getReservationsByUser(user: User): Observable<PagedResults<EquipmentReservation>> {
    return this.http.get<PagedResults<EquipmentReservation>>(environment.apiHost + 'equipmentReservation/userReservations/'+ user.id)
  }

  deleteReservation(id: number): Observable<EquipmentReservation> {
    return this.http.delete<EquipmentReservation>(environment.apiHost + 'equipmentReservation/' + id);
  }

  getEquimpent(id:number): Observable<Equipment> {
    return this.http.get<Equipment>(
      environment.apiHost + 'equipment/' + id
    );
  }

  getEquipmentCount(id: number, wishedCount: number): Observable<boolean> {
    const url = `${environment.apiHost}equipment/checkcount/${id}?wishedCount=${wishedCount}`;
    
    return this.http.get<boolean>(url);
  }
  updateRate(interval: number): Observable<boolean> {
    const url = `http://localhost:3000/send-coordinates`;
    return this.http.post<boolean>(url,{
      interval:interval,
      pocetak: [19.7749461,45.244959],
      kraj: [19.7424984,45.2502712]
    });
  }
}

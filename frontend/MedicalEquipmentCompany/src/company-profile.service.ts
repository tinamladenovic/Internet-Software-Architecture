import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CompanyProfile } from './model/company-profile.model';
import { Observable } from 'rxjs';
import { PagedResults } from './model/page-results.model';
import { environment } from './env/enviroment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class CompanyProfileService {

  constructor(private http: HttpClient, router : Router) { }

  getCompanyProfiles(): Observable<PagedResults <CompanyProfile>> {
    
    return this.http.get<PagedResults<CompanyProfile>>('');
  }

  getCompanyProfile(id : number) : Observable<CompanyProfile> {
    return this.http.get<CompanyProfile>(environment.apiHost + 'company/' +id);
  }
}

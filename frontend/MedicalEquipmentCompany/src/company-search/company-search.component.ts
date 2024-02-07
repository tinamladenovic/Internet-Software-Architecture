import { Component,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppService } from '../app.service';
import { CompanyProfile } from '../model/company-profile.model';
import { PagedResults } from '../model/page-results.model';
import { FormsModule } from '@angular/forms';
import { SearchInputsComp } from '../model/searchInputs.model';
import { User } from '../model/user.model';
import { Router, RouterModule } from '@angular/router';
import { CompanyProfileService } from '../company-profile.service';


@Component({
  selector: 'app-company-search',
  standalone: true,
  imports: [CommonModule,FormsModule, RouterModule],
  templateUrl: './company-search.component.html',
  styleUrl: './company-search.component.css',
})
export class CompanySearchComponent implements OnInit {


  public searchInput: SearchInputsComp = {
    name:'',
    address:''
  }
  public min:number = 0;
  public max:number = 5;
  public searchDone:Boolean = false;
  public companies: CompanyProfile[] = [];
  public filteredCompanies: CompanyProfile[] = [];
  
  user: User | undefined;
  constructor(private service:AppService, private router : Router){}


  ngOnInit(): void {
    this.getCompanies();

      this.service.user$.subscribe((user) => {
        this.user = user;
        console.log(this.user)
      });

  }
  getCompanies(){
    this.service.getCompanies().subscribe((comapnies:PagedResults<CompanyProfile>)=>{
      this.companies = comapnies.results;
      this.filteredCompanies = comapnies.results;
    })
  }
  searchCompanies(){
    this.service.searchCompanies(this.searchInput).subscribe((comapnies:PagedResults<CompanyProfile>)=>{
      this.companies = comapnies.results;
      this.filteredCompanies = comapnies.results;
      this.searchDone = true;
    })
  }

  filterCompanies(){
    this.filteredCompanies = this.companies.filter((company:CompanyProfile)=>{
      return ((company.averageCompanyRating >= this.min) && (company.averageCompanyRating <= this.max))
    })
  }

  viewCompanyProfile(id : number) : void {
    this.router.navigate(['/companyProfile', id]);
  }


}

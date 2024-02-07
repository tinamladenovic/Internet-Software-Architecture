import { Component, Input, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Equipment } from '../model/equipment.model';
import { AppService } from '../app.service';
import { PagedResults } from '../model/page-results.model';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyProfile } from '../model/company-profile.model';

@Component({
  selector: 'app-company-equipment',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './company-equipment.component.html',
  styleUrl: './company-equipment.component.css'
})
export class CompanyEquipmentComponent  {
  @Input() company !: CompanyProfile ;
  public companyId : number | undefined;
  public equipments: Equipment[] = [];
user: any;
  constructor(private service:AppService, private router : Router, private route : ActivatedRoute){}

  ngOnInit(changes: SimpleChanges): void {
    this.service.user$.subscribe((user) => {
      this.user = user;
      console.log(this.user)
    });
    this.route.params.subscribe(params => {
      const id = +params['id']; 
      if (!isNaN(id)) {
        this.companyId = id; 
        this.getEquipment();
      } else {
    } } )
      
    }

  getEquipment(){
    this.service.getEquipmentByCompany(this.company).subscribe((equipment:PagedResults<Equipment>)=>{
      this.equipments = equipment.results;
    })
  }

  reserveDate(id : Number, eId : Number ) : void{
    this.router.navigate(['/companyDates', id, eId]);
  }
}

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Equipment } from '../model/equipment.model';
import { AppService } from '../app.service';
import { PagedResults } from '../model/page-results.model';
import { SearchInputsEquip } from '../model/searchInputs.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-equipment-search',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './equipment-search.component.html',
  styleUrl: './equipment-search.component.css'
})
export class EquipmentSearchComponent {
  public searchInput: SearchInputsEquip = {
    name:'',
  }
  public equipments: Equipment[] = [];

  constructor(private service:AppService){}


  ngOnInit(): void {
    this.getEquipment();
  }

  getEquipment(){
    this.service.getEquipment().subscribe((equipment:PagedResults<Equipment>)=>{
      this.equipments = equipment.results;
    })
  }
  searchEquipment(){
    this.service.searchEquipment(this.searchInput).subscribe((equipment:PagedResults<Equipment>)=>{
      this.equipments = equipment.results;
    })
  }
  

}

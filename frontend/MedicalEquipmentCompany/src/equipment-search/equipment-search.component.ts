import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Equipment } from '../model/equipment.model';
import { AppService } from '../app.service';
import { PagedResults } from '../model/page-results.model';
import { SearchInputsEquip } from '../model/searchInputs.model';
import { FormsModule } from '@angular/forms';
import { EquipmentFormComponent } from '../equipment-form/equipment-form.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCommonModule } from '@angular/material/core';
import { MatIconButton } from '@angular/material/button';

@Component({
  selector: 'app-equipment-search',
  standalone: true,
  imports: [CommonModule,FormsModule,EquipmentFormComponent, MatFormFieldModule, MatCommonModule],
  templateUrl: './equipment-search.component.html',
  styleUrl: './equipment-search.component.css'

 
})
export class EquipmentSearchComponent {
  public searchInput: SearchInputsEquip = {
    name:'',
  }
  public equipments: Equipment[] = [];
  
  selectedEquipment: Equipment = {
    id: 0,
    name: '',
    type: '',
    quantityInStock: 0,
    price: 0,
    description: '',
    companyId: 0,
  };
  
  shouldRenderEquipmentForm: boolean = false;
  shouldEdit: boolean = false;

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
  deleteEquipment(id: number): void {
    this.service.deleteEquipment(id).subscribe({
      next: () => {
        this.getEquipment();
      },
      error: (err) => {
        console.error('Error deleting equipment:', err);
        // Handle error if needed
      }
    });
  }
  
  onEditClicked(equipment: Equipment): void {
    this.selectedEquipment = equipment;
    this.shouldRenderEquipmentForm = true;
    this.shouldEdit = true;
  }

  onAddClicked(): void {
    this.shouldEdit = false;
    this.shouldRenderEquipmentForm = true;
  }

}

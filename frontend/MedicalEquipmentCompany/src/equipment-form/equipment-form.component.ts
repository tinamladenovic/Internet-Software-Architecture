import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Equipment } from '../model/equipment.model';
import { AppService } from '../app.service';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { OnChanges } from '@angular/core';
import { Output, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { EventEmitter } from '@angular/core';
import { SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-equipment-form',
  standalone: true,
  imports: [CommonModule,FormsModule,MatFormFieldModule, ReactiveFormsModule],
  templateUrl: './equipment-form.component.html',
  styleUrl: './equipment-form.component.css'
})
export class EquipmentFormComponent implements OnChanges {

  @Output() equipmentUpdated = new EventEmitter<null>();
  @Input() equipment: Equipment = {
    id: 0,
    name: '',
    type: '',
    quantityInStock: 0,
    price: 0,
    description: '',
    companyId: 0,
  };
  
  @Input() shouldEdit: boolean = false;

  constructor(private service: AppService) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['equipment'] && this['equipment']) {
      this.equipmentForm.patchValue({
        id: this['equipment'].id,
        name: this['equipment'].name,
        type: this['equipment'].type,
        quantityInStock: String(this['equipment'].quantityInStock),
        price: String(this['equipment'].price),
        description: this['equipment'].description,
        companyId: this['equipment'].companyId
      });
    }
  }
  
  equipmentForm = new FormGroup({
    id: new FormControl(0, [Validators.required, Validators.pattern(/^[1-9]\d*$/)]),
    name: new FormControl('', [Validators.required]),
    type: new FormControl('', [Validators.required]),
    quantityInStock: new FormControl('', [Validators.required, Validators.min(0)]),
    price: new FormControl('', [Validators.required, Validators.min(0)]),
    description: new FormControl('', [Validators.required]),
    companyId: new FormControl(0, [Validators.required, Validators.pattern(/^[1-9]\d*$/)]),
  });
  

  addEquipment(): void {
    
    const equipment: Equipment = {
      id: this.equipmentForm.value.id || 0,
      name: this.equipmentForm.value.name || "",
      type: this.equipmentForm.value.type || "",
      quantityInStock: Number(this.equipmentForm.value.quantityInStock) || 0,
      price: Number(this.equipmentForm.value.price) || 0,
      description: this.equipmentForm.value.description || "",
      companyId: this.equipmentForm.value.companyId || 0,
    };
  
    this.service.addEquipment(equipment).subscribe({
      next: () => {
        console.log('Equipment added successfully.');
        this.equipmentUpdated.emit();
      },
      error: (err) => {
        console.error("Error adding equipment:", err);
      }
    });
  }
  
  
  
  updateEquipment(): void {
    const equipment: Equipment = {
      id: this.equipmentForm.value.id || 0,
      name: this.equipmentForm.value.name || "",
      type: this.equipmentForm.value.type || "",
      quantityInStock: Number(this.equipmentForm.value.quantityInStock) || 0,
      price: Number(this.equipmentForm.value.price) || 0,
      description: this.equipmentForm.value.description || "",
      companyId: this.equipmentForm.value.companyId || 0,
    };
  
    this.service.updateEquipment(equipment).subscribe({
      next: () => this.equipmentUpdated.emit(),
      error: (err) => console.error("Greška prilikom ažuriranja opreme:", err),
    });
  }
  
  
  }










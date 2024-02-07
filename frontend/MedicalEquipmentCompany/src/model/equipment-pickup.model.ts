import { Time } from "@angular/common";


export interface EquipmentPickup{
    id?: number;
    administratorId: number;
    companyId: number;
    dateAndTime: Date;
    duration: number;
    isReserved: boolean;

};
export interface EquipmentReservation {
id?:number;
userId : number;
companyId : number;
reservationDate : Date;
reservationStatus : Status;
reservedEquipment : number[];
equipmentCount : number[];
equipmentPickup: number;
}

export enum Status {
    OnWait,
    Completed,
    Expired,
    Canceled
}
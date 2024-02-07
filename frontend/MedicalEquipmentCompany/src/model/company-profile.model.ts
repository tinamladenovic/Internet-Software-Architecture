export interface CompanyProfile {
    id: number;
    administratorIds:number[];
    name: string;
    country: string;
    city: string;
    street: string;
    description: string;
    averageCompanyRating: number;
    //equipmentStock:number[];
    companyWorkingHours:number[];
}

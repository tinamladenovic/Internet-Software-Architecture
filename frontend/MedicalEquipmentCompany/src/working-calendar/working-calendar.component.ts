import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppService } from '../app.service';
import { CompanyWorkingHours } from '../model/company-working-hours.model';
import { PagedResults } from '../model/page-results.model';
import { OnInit } from '@angular/core';


@Component({
  selector: 'app-working-calendar',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './working-calendar.component.html',
  styleUrl: './working-calendar.component.css'
})
export class WorkingCalendarComponent implements OnInit {

  companyWorkingHours: CompanyWorkingHours[] = [];
  

  constructor(private appService: AppService){}

  ngOnInit() : void{
    this.getWorkingHours();
  }

  getWorkingHours(): void {
    this.appService.getWorkingHours().subscribe({
      next: (result: PagedResults<CompanyWorkingHours>) => {
        this.companyWorkingHours = result.results;
      },
      error: () => {
        // Handle error if needed
        console.error('Error fetching equipment reservations');
      }
    });
  
}
getDayOfWeekText(dayOfWeek: number): string {
  switch (dayOfWeek) {
    case 1:
      return 'Monday';
    case 2:
      return 'Tuesday';
    case 3:
      return 'Wednesday';
    case 4:
      return 'Thursday';
    case 5:
      return 'Friday';
    case 6:
      return 'Saturday';
    case 7:
      return 'Sunday';
    default:
      return 'Unknown Day';
  }
}

getHours(date:string){
  let newDate = new Date(date);
  if (newDate.getHours() == 0) {
    return '00:00'
  }
  return (newDate.getHours()+':00')
}


}

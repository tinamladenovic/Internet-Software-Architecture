import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterModule } from '@angular/router';

@Component({
  selector: 'app-companyadmin-homepage',
  standalone: true,
  imports: [CommonModule, RouterModule, RouterLink],
  templateUrl: './companyadmin-homepage.component.html',
  styleUrl: './companyadmin-homepage.component.css'
})
export class CompanyadminHomepageComponent {

}

import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideToastr } from 'ngx-toastr';
import { LeafletModule } from '@asymmetrik/ngx-leaflet';

bootstrapApplication(AppComponent, appConfig )
  .catch((err) => console.error(err));

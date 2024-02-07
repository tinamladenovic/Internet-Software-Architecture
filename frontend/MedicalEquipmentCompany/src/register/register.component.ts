import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, FormControl, FormGroup, ReactiveFormsModule, ValidationErrors, ValidatorFn, Validators} from '@angular/forms'
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { AppService } from '../app.service';
import { Registration } from '../model/registration.model';
import { TokenStorage } from '../jwt/token.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatButtonModule, MatFormFieldModule, MatInputModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  constructor(
    private service: AppService,
    private router: Router,
    private tokenStorage: TokenStorage
  ) {}

registrationForm = new FormGroup({
  email: new FormControl('', [Validators.required,Validators.email]),
  password: new FormControl('', [Validators.required]),
  confirmPassword:new FormControl('', [Validators.required]),
  name: new FormControl('', [Validators.required]),
  surname: new FormControl('', [Validators.required]),
  city: new FormControl('', [Validators.required]),
  state: new FormControl('', [Validators.required]),
  phoneNumber: new FormControl('', [Validators.required]),
  profession: new FormControl('', [Validators.required]),
  enterprise: new FormControl('', [Validators.required]),
})
// All is this method
onPasswordChange() {
  if (this.confirm_password.value == this.password.value) {
    this.confirm_password.setErrors(null);
  } else {
    this.confirm_password.setErrors({ mismatch: true });
  }
}

// getting the form control elements
get password(): AbstractControl {
  return this.registrationForm.controls['password'];
}

get confirm_password(): AbstractControl {
  return this.registrationForm.controls['confirmPassword'];
}
register(): void {
  const registration: Registration = {
    email: this.registrationForm.value.email || "",
    password: this.registrationForm.value.password || "",
    confirmPassword: this.registrationForm.value.confirmPassword || "",
    name: this.registrationForm.value.name || "",
    surname: this.registrationForm.value.surname || "",
    city: this.registrationForm.value.city || "",
    country: this.registrationForm.value.state || "",
    phone: this.registrationForm.value.phoneNumber || "",
    profession: this.registrationForm.value.profession || "",
    enterprise: this.registrationForm.value.enterprise || "",
    penalties: 0,
  };

  if (this.registrationForm.valid) {
    this.service.register(registration).subscribe({
      next: (value) => {
        this.tokenStorage.saveAccessToken(value.accessToken);
        this.service.setUser();
        this.router.navigate(['']);
      },
    });
  }
}
}

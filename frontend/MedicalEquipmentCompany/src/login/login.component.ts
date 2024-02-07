import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms'
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Login } from '../model/login.model';
import { AppService } from '../app.service';
import { Router } from '@angular/router';
import { TokenStorage } from '../jwt/token.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatButtonModule, MatFormFieldModule, MatInputModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  errorMessage: string | null = null;
  constructor(
    private authService: AppService,
    private router: Router,
    private tokenStorage: TokenStorage,
  ) {}

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  login(): void {
    const login: Login = {
      email: this.loginForm.value.email || "",
      password: this.loginForm.value.password || "",
    };

    if (this.loginForm.valid) {
      this.authService.login(login).subscribe({
        next: (value) => {
          this.router.navigate(['/']);
        },
        error: (err) => {
          console.error('Login error:', err);
        
          if (err.status === 400 && err.error && err.error.errors && err.error.errors.token) {
            // If the error is due to missing or invalid token
            this.errorMessage = 'You need to sing up or verify your email.';
          } else {
            this.errorMessage = 'You need to sing up or verify your email.';
          }
        }
      });
    }
  }
}

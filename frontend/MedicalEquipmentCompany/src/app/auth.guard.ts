import { Injectable, inject,OnInit} from '@angular/core';
import {
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  CanActivateFn,
} from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../model/user.model';
import { map } from 'rxjs/operators';
import { AppService } from '../app.service';
import { TokenStorage } from '../jwt/token.service';
@Injectable({
  providedIn: 'root',
})
class PermissionsService  {

  constructor(private router: Router,private service:AppService,private tokenStorage:TokenStorage) {
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const accessToken = this.tokenStorage.getAccessToken()
    if (accessToken !== null) {
      return true;
    }
    return false
  }
}

export const AuthGuard: CanActivateFn = (next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
  return inject(PermissionsService).canActivate(next, state)
}

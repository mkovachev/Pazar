import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { AuthService } from '../auth.service';
import { Login } from './login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup<Login>;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router) {
    if (localStorage.getItem('token')) {
      this.router.navigate(['']);
    }
  }

  ngOnInit() {
    localStorage.removeItem('token');
    this.loginForm = this.fb.group<Login>({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe(res => {
      this.authService.saveToken(res.token);
      this.authService.saveUserId(res.id);

        this.router.navigate(['']).then(() => {
          window.location.reload();
        });
      });
  }
}

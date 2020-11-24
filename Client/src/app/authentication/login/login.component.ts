import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { AuthenticationService } from '../authentication.service';
import { LoginFormModel } from './login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup<LoginFormModel>;
  authenticationService!: AuthenticationService;

  constructor(
    private fb: FormBuilder,
    private router: Router) {
    if (localStorage.getItem('token')) {
      this.router.navigate(['ads']);
    }
  }

  ngOnInit(): void {
    localStorage.removeItem('token');
    this.loginForm = this.fb.group<LoginFormModel>({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login(): void {
    this.authenticationService.login(this.loginForm.value).subscribe(res => {
      this.authenticationService.setToken(res.token);

      this.authenticationService.getUserId().subscribe(res => {
        this.authenticationService.setId(res);

        this.router.navigate(['']).then(() => {
          window.location.reload();
        });
      });
    });
  }
}

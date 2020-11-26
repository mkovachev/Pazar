import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { AuthenticationService } from '../authentication.service';
import { ILoginModel } from './login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  //styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup<ILoginModel>;

  constructor(
    private fb: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router) {
    if (localStorage.getItem('token')) {
      this.router.navigate(['ads']);
    }
  }

  ngOnInit() {
    localStorage.removeItem('token');
    this.loginForm = this.fb.group<ILoginModel>({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
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

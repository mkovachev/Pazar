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
  returnUrl!: string;
  @Output() emitter: EventEmitter<string> = new EventEmitter<string>();

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router) {
    if (localStorage.getItem('token')) {
      this.router.navigate(['ads']);
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
      this.authService.setToken(res.token);

      // this.authService.getUserId().subscribe(res => {
      //   this.authService.setId(res);

      this.router.navigate(['']).then(() => {
        window.location.reload();
      });
    });
    //});
  }
}

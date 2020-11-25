import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';
import { IRegisterModel } from './register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup<IRegisterModel>;

  constructor(
    private fb: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router) { }

  ngOnInit() {
    this.registerForm = this.fb.group<IRegisterModel>({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  register() {
    const input = this.registerForm.value;

    this.authenticationService.register(input).subscribe(res => {
      this.authenticationService.setToken(res.token);

      this.authenticationService.createUser(input).subscribe(res => {
        this.authenticationService.setId(res);

        this.router.navigate(['']).then(() => {
          window.location.reload();
        });
      });
    });
  }
}

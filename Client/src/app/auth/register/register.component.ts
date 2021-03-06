import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { Register } from './register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
  registerForm!: FormGroup<Register>;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit() {
    this.registerForm = this.fb.group<Register>({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(res => {
      this.authService.saveToken(res.token);
      this.router.navigate(['']);
    });
  }
}

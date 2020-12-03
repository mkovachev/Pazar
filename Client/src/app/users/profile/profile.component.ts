import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { PasswordChange } from '../password.model';
import { User } from '../user.model';
import { UsersService } from '../users.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})

export class ProfileComponent implements OnInit {
  profileForm!: FormGroup<User>;
  changePasswordForm!: FormGroup<PasswordChange>;
  user!: User;
  id!: string;

  constructor(
    private fb: FormBuilder,
    private userService: UsersService,
    private router: Router,
    private route: ActivatedRoute) {
    this.changePasswordForm = this.fb.group<PasswordChange>({
      currentPassword: [null, Validators.required],
      newPassword: [null, Validators.required],
    })
  }

  ngOnInit(): void {
    this.id = localStorage.getItem('userId')!;
    this.userService.find(this.id).subscribe(user => {
      this.user = user
      this.profileForm = this.fb.group<User>({
        name: [this.user.name],
        email: [this.user.email],
        phoneNumber: [this.user.phoneNumber]
      })
    })
  }

  editProfile() {
    this.userService.edit(this.id, this.profileForm.value).subscribe(res => {
      this.router.navigate(['users', 'profile'])
    })
  }

  changePassword() {
    this.userService.changePassword(this.changePasswordForm.value).subscribe(res => {
      localStorage.clear()
      window.location.reload()
      this.router.navigate(['users', 'profile'])
    })
  }

}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { PasswordChange } from '../password.model';
import { User } from '../user.model';
import { UsersService } from '../users.service';
import { ToastrService } from 'ngx-toastr';

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
    public toastr: ToastrService) {
    this.changePasswordForm = this.fb.group<PasswordChange>({
      currentPassword: [null, Validators.required],
      newPassword: [null, Validators.required]
    })
  }

  ngOnInit(): void {
    this.id = localStorage.getItem('userId')!;
    this.userService.find(this.id).subscribe(u => {
      this.user = u
      this.profileForm = this.fb.group<User>({
        name: [this.user.name],
        email: [this.user.email],
        phoneNumber: [this.user.phoneNumber]
      })
    })
  }

  edit() {
    this.userService.edit(this.id, this.profileForm.value).subscribe(res => {
      this.router.navigate(['users', 'profile'])
      this.toastr.info("Your profile has been updated")
    })
  }

  changePassword() {
    this.userService.changePassword(this.id, this.changePasswordForm.value).subscribe(res => {
      console.log(res)
      localStorage.clear()
      window.location.reload()
      this.router.navigate(['ads', 'myads'])
    })
  }

}

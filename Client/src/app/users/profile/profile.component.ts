import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@ng-stack/forms';
import { PasswordChange } from './password.model';
import { Profile } from './profile.model';
import { ProfileService } from './profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})

export class ProfileComponent implements OnInit {
  profileForm!: FormGroup<Profile>;
  changePasswordForm!: FormGroup<PasswordChange>;
  user!: Profile;
  id!: string;

  constructor(
    private fb: FormBuilder,
    private profileService: ProfileService,
    private router: Router) {
    this.changePasswordForm = this.fb.group<PasswordChange>({
      currentPassword: ['', Validators.required],
      newPassword: ['', Validators.required],
    })
  }

  ngOnInit(): void {
    this.id = localStorage.getItem('userId')!;
    this.profileService.getUser(this.id).subscribe(u => {
      this.user = u
      console.log(u.name)
      this.profileForm = this.fb.group<Profile>({
        id: [this.user.id, Validators.required],
        name: [this.user.name, Validators.required],
        phoneNumber: [this.user.phoneNumber, Validators.required],
      })
      console.log(this.profileForm.value)
    })
  }

  fetchUser() {
    // this.profileService.getUser(this.id).subscribe(res => {
    //   this.router.navigate(['user/id'])
    // })
  }

  editProfile() {
    this.profileService.editUser(this.id, this.profileForm.value).subscribe(res => {
      this.router.navigate(['ads'])
    })
  }

  changePassword() {
    this.profileService.changePassword(this.changePasswordForm.value).subscribe(res => {
      localStorage.clear()
      window.location.reload()
      this.router.navigate(['auth']);
    })
  }

}

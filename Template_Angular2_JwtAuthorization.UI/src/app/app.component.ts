import { Component } from '@angular/core';
import { UserService } from "app/_services/user.service";
import { AuthenticationService } from "app/_services/authentication.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app works!';
  myInfo: any;

  constructor(public userService: UserService,
    public authService: AuthenticationService) {

  }

  showMyInfo() {
    this.userService.getMyInfo().
      subscribe(
      data => {
        this.myInfo = data;
      },
      error => {
        this.myInfo = "Error Occured";
      });
  }
}

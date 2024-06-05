import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @Input() usersFromHomeComponent: any; // this prop gets passed down from within the home.component.html template

  model: any = {}

  register() {
    console.log(this.model)
  }
  cancel() {
    console.log('cancel')
  }

}

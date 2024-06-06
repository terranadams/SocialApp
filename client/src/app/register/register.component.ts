import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @Input() usersFromHomeComponent: any; // this prop gets passed down from within the home.component.html template
  @Output() cancelRegister = new EventEmitter(); // this passes data from this child component to the parent home.component

  model: any = {}

  register() {
    console.log(this.model)
  }
  cancel() {
    this.cancelRegister.emit(false)
  }

}

import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @Output() cancelRegister = new EventEmitter(); // this passes data from this child component to the parent home.component

  model: any = {}

  constructor(private accountService: AccountService, private toastr: ToastrService) {}

  register() {
    this.accountService.register(this.model).subscribe({
      next: response => {
        // console.log(response);
        this.cancel();
      },
      error: error => {
        this.toastr.error(error.error)
        console.log(error)
      }
    })
  }
  cancel() {
    this.cancelRegister.emit(false)
  }

}

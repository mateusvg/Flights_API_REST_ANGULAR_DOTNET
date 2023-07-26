import { Component, OnInit } from '@angular/core';
import { PassengerService } from './../api/services/passenger.service'
import { FormBuilder } from '@angular/forms'
import { AuthService } from '../auth/auth.service'

@Component({
  selector: 'app-register-passenger',
  templateUrl: './register-passenger.component.html',
  styleUrls: ['./register-passenger.component.css']
})
export class RegisterPassengerComponent implements OnInit {

  //FormBuilder (utilizado no app.module ReactiveFormsModule)
  constructor(private passengerService: PassengerService,
    private fb: FormBuilder,
    private authService: AuthService
  ) { }

  //São os pares/matches/bind de como o atributo form é dentro do html
  //<form [formGroup]="form">
  //      <input formControlName="email" placeholder="Email" class="form-control" type="text" />
  form = this.fb.group({
    email: [''],
    firstName: [''],
    lastName: [''],
    isFemale: [true],

  })

  ngOnInit(): void {
  }

  checkPassenger() {
    const params = { email: this.form.get('email')?.value }

    this.passengerService.findPassenger(params).subscribe(_ => {
      console.log("Passenger exists. Loggin in now")
      this.authService.loginUser({ email: this.form.get('email')?.value })
    })
  }

  //metodo chamado quando um cliente registra , passando o data-binding do html no form
  register() {
    console.log("FORMS VALUES:", this.form.value)
    //passa o form.value para o backend
    this.passengerService.registerPassenger({ body: this.form.value })
      .subscribe(_ => this.authService.loginUser({ email: this.form.get('email')?.value }),

        console.error
      )
  }

}

import { Component, OnInit } from '@angular/core';
import { PassengerService } from './../api/services/passenger.service'
import { FormBuilder, Validators } from '@angular/forms'
import { AuthService } from '../auth/auth.service'
import { Router } from '@angular/router'

@Component({
  selector: 'app-register-passenger',
  templateUrl: './register-passenger.component.html',
  styleUrls: ['./register-passenger.component.css']
})
export class RegisterPassengerComponent implements OnInit {

  //FormBuilder (utilizado no app.module ReactiveFormsModule)
  constructor(private passengerService: PassengerService,
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
  ) { }

  //São os pares/matches/bind de como o atributo form é dentro do html
  //<form [formGroup]="form">
  //      <input formControlName="email" placeholder="Email" class="form-control" type="text" />
  form = this.fb.group({
    email: ['', Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(100), Validators.pattern('^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]+$')])],
    firstName: ['', Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(35)])],
    lastName: ['', Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(35)])],
    isFemale: [true, Validators.required]

  })

  ngOnInit(): void {
  }

  checkPassenger() {
    const params = { email: this.form.get('email')?.value }

    this.passengerService.findPassenger(params).subscribe(_ => { this.authService.loginUser({ email: this.form.get('email')?.value }) }, e => {
      if (e.status != 400)
        console.error(e)
    })
  }

  //metodo chamado quando um cliente registra , passando o data-binding do html no form
  register() {

    if (this.form.invalid)
      return

    console.log("FORMS VALUES:", this.form.value)
    //passa o form.value para o backend
    this.passengerService.registerPassenger({ body: this.form.value })
      .subscribe(this.login,
        console.error
      )
  }

  private login = () => {
    this.authService.loginUser({ email: this.form.get('email')?.value })
    this.router.navigate(['/search-flights'])
  }

}

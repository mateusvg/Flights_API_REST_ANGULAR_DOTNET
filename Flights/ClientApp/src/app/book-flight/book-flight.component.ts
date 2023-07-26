import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'
import { FlightService } from './../api/services/flight.service'
import { FlightRm } from '../api/models'
import { AuthService } from '../auth/auth.service'

@Component({
  selector: 'app-book-flight',
  templateUrl: './book-flight.component.html',
  styleUrls: ['./book-flight.component.css']
})
export class BookFlightComponent implements OnInit {

  flightId: string = "Not loaded"
  flight: FlightRm = {}

  constructor(private route: ActivatedRoute,
    private flightService: FlightService,
    private router: Router,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    if (!this.authService.currentUser)
      this.router.navigate(['/register-passenger'])
    this.route.paramMap.subscribe(p => this.findFlight(p.get("flightId")))
  }

  private findFlight = (flightId: string | null) => {
    this.flightId = flightId ?? 'not passed'

    this.flightService.findFlight({ id: this.flightId }).subscribe(flight => this.flight = flight, this.handleError)

  }
  private handleError = (err: any) => { //tratamento de erro
    if (err.status == 400) {
      alert("Flight Not Found")
      this.router.navigate(['/search-flights']) //redireconamento caso não encontre o ID do voo, para que o redirecinamento funcione, o metodo handleError tem que ser arrow function
    }
    console.log("Response Error. Status:", err.status)
    console.log("Response Error. Status:", err.statusText)
    console.log(err)
  }



}

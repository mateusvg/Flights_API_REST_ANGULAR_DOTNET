import { Component, OnInit } from '@angular/core';
import { FlightService } from './../api/services/flight.service'
import { FlightRm } from '../api/models'

@Component({
  selector: 'app-search-flights',
  templateUrl: './search-flights.component.html',
  styleUrls: ['./search-flights.component.css']
})
export class SearchFlightsComponent implements OnInit {

  searchResult: FlightRm[] = []


  /*  searchResult: FlightRm[] = [
      {
        airline: "Americam Airlines",
        remainingNumberOfSeats: 600,
        departure: { time: Date.now().toString(), place: "Los Angeles" },
        arrival: { time: Date.now().toString(), place: "Istanbul" },
        price: "350",
  
      },
      {
        airline: "Latam",
        remainingNumberOfSeats: 300,
        departure: { time: Date.now().toString(), place: "Belo Horizonte" },
        arrival: { time: Date.now().toString(), place: "São Paulo" },
        price: "150",
      }
  
    ]
    */



  constructor(private flightService: FlightService) { }

  ngOnInit(): void {
  }

  search() {
    this.flightService.searchFlight({}).subscribe(response => this.searchResult = response, this.handleError)
  }
  private handleError(err: any) { //tratamento de erro
    console.log("Response Error. Status:", err.status)
    console.log("Response Error. Status:", err.statusText)
    console.log(err)
  }
}



/*
export interface FlightRm {
  airline: string;
  arrival: TimePlaceRm; // a pripriedade arrival esta ligada as pripriedade place e time em TimePLaceRm
  departure: TimePlaceRm;
  price: string;
  remainingNumberOfSeats: number;

}


export interface TimePlaceRm {
  place: string;
  time: string;
}*/

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  currentUser?: User

  loginUser(user: User) {
    console.log("Login the user with email" + user.email)
    this.currentUser = user
  }

}

interface User {
  email: string
}

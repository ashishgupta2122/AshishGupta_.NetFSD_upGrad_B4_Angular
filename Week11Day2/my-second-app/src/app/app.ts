import { Component} from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
import {CommonModule} from '@angular/common';
import {AuthService} from './auth.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterLink, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  constructor(public auth: AuthService) {}

  login() {
    this.auth.login();
  }

  logout() {
    this.auth.logout();
  }
}

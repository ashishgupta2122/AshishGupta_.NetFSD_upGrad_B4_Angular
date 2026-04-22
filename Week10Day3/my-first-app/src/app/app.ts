import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {
  title = 'My First Angular App';

  changeTitle() {
    this.title = 'Title Changed!';
  }
}

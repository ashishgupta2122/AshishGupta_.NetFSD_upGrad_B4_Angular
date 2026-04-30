import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Contact } from './contact';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  contacts: Contact[] = [
    { contactId: 1, name: 'Ashish', email: 'ashish@gmail.com', phone: '9999999999', isActive: true },
    { contactId: 2, name: 'Kiya', email: 'kiya@gmail.com', phone: '8888888888', isActive: false },
    { contactId: 3, name: 'Rahul', email: 'rahul@gmail.com', phone: '7777777777', isActive: true }
  ];

}
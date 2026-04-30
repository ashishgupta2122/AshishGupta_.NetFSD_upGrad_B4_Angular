import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Contact } from './contact';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  contacts: Contact[] = [];

  contact: Contact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    isActive: false
  };

  addContact(form: any) {
    if (form.valid) {
      this.contact.contactId = this.contacts.length + 1;

      this.contacts.push({ ...this.contact });

      form.resetForm(); // reset form

      this.contact = {
        contactId: 0,
        name: '',
        email: '',
        phone: '',
        isActive: false
      };
    }
  }
}
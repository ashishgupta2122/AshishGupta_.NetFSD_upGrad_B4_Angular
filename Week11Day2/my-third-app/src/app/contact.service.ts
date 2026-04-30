import { Injectable } from '@angular/core';
import { Contact } from './contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private contacts: Contact[] = [
    { id: 1, name: 'Ashish', email: 'ashish@gmail.com', phone: '9999999999' },
    { id: 2, name: 'Kiya', email: 'kiya@gmail.com', phone: '8888888888' }
  ];

  // Get all contacts
  getContacts(): Contact[] {
    return this.contacts;
  }

  // Add new contact
  addContact(contact: Contact): void {
    this.contacts.push(contact);
  }

  // Get by ID
  getContactById(id: number): Contact | undefined {
    return this.contacts.find(c => c.id === id);
  }
}
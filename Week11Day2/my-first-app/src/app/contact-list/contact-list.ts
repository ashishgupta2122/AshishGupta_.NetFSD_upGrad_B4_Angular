import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {Contact} from '../contact';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './contact-list.html'
})

export class ContactList {
  contacts: Contact[] = [
    {id: 1, name: 'Ashish', email: 'ashish@gmail.com', phone: '9999999999'},
    {id: 2, name: 'Basu', email: 'basu@gmail.com', phone: '8888888888'}
  ];
}
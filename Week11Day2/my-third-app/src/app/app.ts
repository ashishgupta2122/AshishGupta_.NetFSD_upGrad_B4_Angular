import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AddContactComponent } from './add-contact/add-contact.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { ContactDetailComponent } from './contact-detail/contact-detail.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    AddContactComponent,
    ContactListComponent,
    ContactDetailComponent
  ],
  templateUrl: './app.html'
})
export class App {}
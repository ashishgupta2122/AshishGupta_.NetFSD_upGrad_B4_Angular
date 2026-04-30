import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ContactService} from '../contact.service';
import {Contact} from '../contact';

@Component({
    selector: 'app-contact-list',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './contact-list.component.html'
})

export class ContactListComponent {
    contacts: Contact[] = [];

    constructor(private service: ContactService) {
        this.contacts = this.service.getContacts();
    }
}
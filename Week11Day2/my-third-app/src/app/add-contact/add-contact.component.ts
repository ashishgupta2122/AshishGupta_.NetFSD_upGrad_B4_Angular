import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {ContactService} from '../contact.service';

@Component({
    selector: 'app-add-contact',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './add-contact.component.html'
})

export class AddContactComponent {
    contact = {
        id: 0,
        name: '',
        email: '',
        phone: ''
    };

    constructor(private service: ContactService) {}

    addContact() {
        this.contact.id = Math.floor(Math.random() * 1000); // Simple ID generation

        this.service.addContact({ ...this.contact });

        alert('Contact added successfully!');

        // Reset form
        this.contact = {
            id: 0,
            name: '',
            email: '',
            phone: ''
        };
    }
}
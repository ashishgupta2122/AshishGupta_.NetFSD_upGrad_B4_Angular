import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterLink} from '@angular/router';

@Component({
    selector: 'app-contact-list',
    standalone: true,
    imports: [CommonModule, RouterLink],
    templateUrl: './contact-list.html'
})

export class ContactList {
    contacts = [
        {id: 1, name: 'Ashish'},
        {id: 2, name: 'Basu'}
    ]
}
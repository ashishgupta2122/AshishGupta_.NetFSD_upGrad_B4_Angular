import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {CommonModule} from '@angular/common';

@Component({
    selector: 'app-add-contact',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './add-contact.html'
})

export class AddContact {
    constructor(private router: Router) {}

    addContact() {
        alert("Contact Added!");
        this.router.navigate(['/contacts']);
    }
}
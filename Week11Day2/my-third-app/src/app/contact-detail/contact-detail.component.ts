import {Component} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ContactService} from '../contact.service';
import {Contact} from '../contact';

@Component({
    selector: 'app-contact-detail',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './contact-detail.component.html'
})

export class ContactDetailComponent {
    contact?: Contact;

     constructor(private service: ContactService) {
    this.contact = this.service.getContactById(1);
  }
}
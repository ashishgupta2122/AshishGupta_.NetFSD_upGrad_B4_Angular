import { Component } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {CommonModule} from '@angular/common';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.html',
  styleUrl: './contact-detail.css',
})
export class ContactDetail {
  contactId: number = 0;

  constructor(private route: ActivatedRoute) {
    this.contactId = Number(this.route.snapshot.paramMap.get('id'));
  }
}

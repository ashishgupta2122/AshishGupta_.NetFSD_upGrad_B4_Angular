import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import {CommonModule} from '@angular/common';
import {Contact} from './contact';
import { email } from '@angular/forms/signals';
import { isActive } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  contactForm: FormGroup;
  contacts: Contact[] = [];

  constructor(private fb : FormBuilder) {
    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]],
      isActive: [false]
    });
  }

  onSubmit() {
    if(this.contactForm.valid) {
      const newContact: Contact = {
        contactId: this.contacts.length + 1,
        ...this.contactForm.value
      };

      this.contacts.push(newContact);

      this.contactForm.reset();
    }
  }
}

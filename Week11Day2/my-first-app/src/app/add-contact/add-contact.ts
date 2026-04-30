import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // ✅ IMPORTANT

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [CommonModule, FormsModule], // ✅ MUST ADD
  templateUrl: './add-contact.html',
  styleUrl: './add-contact.css',
})
export class AddContact {
  constructor(private router: Router) {}

  addContact() {
    alert("Contact Added!");
    this.router.navigate(['/contacts']);
  }
}
import { Routes } from '@angular/router';
import { ContactList } from './contact-list/contact-list';
import { AddContact } from './add-contact/add-contact';
import { authGuard } from './auth.guard';
import { ContactDetail } from './contact-detail/contact-detail';

export const routes: Routes = [
    {path: '', redirectTo: 'contacts', pathMatch: 'full'},

    {path: 'contacts', component: ContactList},
    {path: 'add-contact', component: AddContact, canActivate: [authGuard]},
    {path: 'contact/:id', component: ContactDetail, canActivate: [authGuard]}
];

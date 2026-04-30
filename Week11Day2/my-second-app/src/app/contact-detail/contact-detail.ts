import {Component} from '@angular/core';
import {ActivatedRoute} from '@angular/router';

@Component({
    selector: 'app-contact-detail',
    standalone: true,
    templateUrl: './contact-detail.html'
})

export class ContactDetail {
    id: any;

    constructor(private route: ActivatedRoute) {
        this.id = this.route.snapshot.paramMap.get('id');
    }
}
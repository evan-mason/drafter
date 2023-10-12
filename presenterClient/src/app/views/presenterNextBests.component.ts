import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'presenter-next-bests',
    templateUrl: "presenterNextBests.component.html",
    styles: []
})
export default class PresenterNextBests implements OnInit {

    constructor(public store: Store) { }

    ngOnInit(): void {
        this.store.loadNextBests().subscribe();
    }
}
import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'presenter-last-pick',
    templateUrl: "presenterLastPick.component.html",
    styles: []
})
export default class PresenterLastPick implements OnInit{

    constructor(public store: Store) {}

    ngOnInit(): void {
        this.store.loadPreviousPick()
            //.subscribe();
    }
}
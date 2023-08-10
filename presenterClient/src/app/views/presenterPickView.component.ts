import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'presenter-pick',
    templateUrl: "presenterPickView.component.html",
    styleUrls: ['presenterPickView.component.css']
})
export default class PresenterPickView implements OnInit{

    constructor(public store: Store) {}

    ngOnInit(): void {
        this.store.loadPicks()
            .subscribe();
    }
}
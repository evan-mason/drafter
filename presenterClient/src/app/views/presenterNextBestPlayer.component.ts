import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'presenter-next-best-player',
    templateUrl: "presenterNextBestPlayer.component.html",
    styles: []
})
export default class PresenterNextBestPlayer implements OnInit {

    constructor(public store: Store) { }

    ngOnInit(): void {
        this.store.loadNextBestPlayer().subscribe();
    }
}
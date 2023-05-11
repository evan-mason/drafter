import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'player-picker',
    templateUrl: "playerPickerView.component.html",
    styles: []
})
export default class PlayerPickerView implements OnInit{

    constructor(public store: Store) {

    }

    ngOnInit(): void {
        this.store.loadPlayers()
            .subscribe();
    }

}
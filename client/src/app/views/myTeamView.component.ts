import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'my-team',
    templateUrl: "myTeamView.component.html",
    styles: []
})
export default class MyTeamView implements OnInit{

    positionOptions!: any[];

    fantasyPositions!: any[];

    constructor(public store: Store) {

    }

    ngOnInit(): void {
        this.store.loadMyPlayers()
            .subscribe();

        this.positionOptions = [
            { label: 'PG', value: 'PG' },
            { label: 'SG', value: 'SG' },
            { label: 'SF', value: 'SF' },
            { label: 'PF', value: 'PF' },
            { label: 'C', value: 'C' }
        ];
    }
}
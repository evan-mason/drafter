import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '../services/store.service';
import { PlayerDto } from '../shared/PlayerDto';

@Component({
    selector: 'my-team',
    templateUrl: "myTeamView.component.html",
    styles: []
})
export default class MyTeamView implements OnInit{

    positionOptions!: any[];

    fantasyPositions!: any[];

    visible: boolean = false;

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

        this.store.refreshDraftboard();
        this.store.refreshDraftboardName();
    }

    ngAfterViewInit() {
        setInterval(() => {
            this.store.refreshDraftboard();
        }, 20000);
    }

    showDialog() {
        this.visible = true;
    }
}
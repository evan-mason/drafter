import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'all-teams',
    templateUrl: "allTeamsView.component.html",
    styles: []
})
export default class AllTeamsView implements OnInit{

    positionOptions!: any[];

    fantasyPositions!: any[];

    currentTeam: number = 2;

    constructor(public store: Store) { }

    ngOnInit(): void {

        this.store.loadTotalTeams().subscribe();

        this.store.loadTeam(2)
            .subscribe();

        this.positionOptions = [
            { label: 'PG', value: 'PG' },
            { label: 'SG', value: 'SG' },
            { label: 'SF', value: 'SF' },
            { label: 'PF', value: 'PF' },
            { label: 'C', value: 'C' }
        ];
    }

    ngAfterViewInit() {
        setInterval(() => {
            this.refreshTeam();
        }, 15000);
    }

    refreshTeam() {
        this.store.loadTeam(this.currentTeam)
            .subscribe();
        this.store.loadTeamName(this.currentTeam)
            .subscribe();
        this.currentTeam++;
        if (this.currentTeam > this.store.totalTeams + 1) { // this is because if 2 is the first team 3 is the second team and so on. total teams is one more than the count.
            this.currentTeam = 2;
        }
    }
}
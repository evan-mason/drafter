import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'dashboard-selected-player',
    templateUrl: "dashboardSelectedPlayer.component.html",
    styles: []
})
export default class DashboardSelectedPlayer implements OnInit{

    constructor(public store: Store) { }

    ngOnInit(): void { // REMOVE THIS WHEN WE FIRE IT VIA THE OTHER TABLE
        //this.store.loadSelectedPlayer(11)
        //    .subscribe();
        //console.log("loadedSelectedPlayer");
    }
}
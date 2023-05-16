import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'my-team',
    templateUrl: "myTeamView.component.html",
    styles: []
})
export default class MyTeamView { //implements OnInit{

    constructor(public store: Store) {

    }

    // ngOnInit(): void {
    //     this.store.loadPlayers()
    //         .subscribe();
    // }

}
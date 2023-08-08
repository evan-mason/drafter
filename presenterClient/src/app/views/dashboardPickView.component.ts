import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'dashboard-pick',
    templateUrl: "dashboardPickView.component.html",
    styles: []
})
export default class DashboardPickView implements OnInit{

    constructor(public store: Store) {}

    ngOnInit(): void {
        this.store.loadPicks()
            .subscribe();
    }
}
import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'dashboard-timeline',
    templateUrl: "dashboardTimelineView.component.html",
    styles: []
})
export default class DashboardTimelineView implements OnInit{

    constructor(public store: Store) { }

    ngOnInit(): void {
        this.store.loadTimeline()
            .subscribe();
    }
}
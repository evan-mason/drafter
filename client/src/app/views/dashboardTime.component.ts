import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'dashboard-time',
    templateUrl: "dashboardTime.component.html",
    styles: []
})
export default class DashboardTime implements OnInit{

    public timer: any;
    public timerMilliseconds: any;
    public lastPickTime: any;
    public difference: any;

    constructor(public store: Store) { }

    ngOnInit(): void {
        this.store.loadTimer()
            .subscribe();
    }

    ngAfterViewInit() {
        setInterval(() => {
            this.tickTock();
        }, 1000);
    }

    tickTock() {
        this.lastPickTime = new Date(this.store.lastPickTime);
        this.timerMilliseconds = this.lastPickTime - new Date().getTime() + 300000; //
        this.timer = Math.floor(this.timerMilliseconds / 1000); //convert to seconds // this is stupid because we are converting back into milliseconds in the html
    }
}
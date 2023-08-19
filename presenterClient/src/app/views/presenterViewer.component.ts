import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'presenter-viewer',
    templateUrl: "presenterViewer.component.html",
    styles: []
})
export default class presenterViewer implements OnInit {

    public currentPage: number = 0;

    constructor(public store: Store) { }

    ngOnInit(): void {
    }

    ngAfterViewInit() {
        setInterval(() => {
            this.nextPage();
        }, 12000); // 12 seconds till page skip
    }

    nextPage() {
        this.store.nextPage();
        // if team page load team from store, and change content that's rendered
        // if palyer page load player from store
        // if best a position load collection of players at position
        // if on trivia, load random trivia/stat
    }
}
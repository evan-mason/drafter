import { Component, OnInit } from '@angular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'presenter-viewer',
    templateUrl: "presenterViewer.component.html",
    styles: []
})
export default class presenterViewer implements OnInit {

    currentPage: number = 0;
    totalPages: number = 4;

    constructor(public store: Store) { }

    ngOnInit(): void {
    }

    ngAfterViewInit() {
        setInterval(() => {
            this.nextPage();
        }, 1000); // 12 seconds till page skip
    }

    nextPage() {
        console.log(this.currentPage);
        this.currentPage++;
        if (this.currentPage === this.totalPages) { // this is because if 2 is the first team 3 is the second team and so on. total teams is one more than the count.
            this.currentPage = 0;
        // if team page load team from store, and change content that's rendered
        // if palyer page load player from store
        // if best a position load collection of players at position
        // if on trivia, load random trivia/stat
        }
    }
}
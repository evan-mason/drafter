import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { Store } from '../services/store.service';

@Component({
    selector: 'player-picker',
    templateUrl: "playerPickerView.component.html",
    styles: []
})
export default class PlayerPickerView implements OnInit{

    positionOptions!: any[];

    constructor(public store: Store) {

    }

    ngOnInit(): void {
        this.store.loadPlayers()
            .subscribe();

        this.positionOptions = [
            { label: 'PG', value: 'PG' },
            { label: 'SG', value: 'SG' },
            { label: 'SF', value: 'SF' },
            { label: 'PF', value: 'PF' },
            { label: 'C', value: 'C' }
        ];
    }

    draftPlayer(): void {} // this is for muting errors

    clear(table: Table, searchText: HTMLInputElement) { // this is to make the clear button work on the table
        table.clear();
        searchText.value = '';
    }

    getEventValue($event:any) :string {
        return $event.target.value;
    } 

}
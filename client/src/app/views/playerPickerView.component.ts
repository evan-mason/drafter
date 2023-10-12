import { Component, OnInit } from '@angular/core';
import { Table } from 'primeng/table';
import { Store } from '../services/store.service';
import { HttpClient } from "@angular/common/http";
import { PlayerDto } from '../shared/PlayerDto';

@Component({
    selector: 'player-picker',
    templateUrl: "playerPickerView.component.html",
    styles: []
})
export default class PlayerPickerView implements OnInit{

    positionOptions!: any[];
    playerDto!: PlayerDto;
    tableTypes!: any[];
    tableType: any = 'Averages';
    playerStatuses!: any[];
    first = 0;
    firstSaved = 0;

    constructor(public store: Store, private http: HttpClient) {
    }

    ngOnInit(): void {
        this.store.loadPlayersWithType()
            .subscribe();

        this.positionOptions = [
            { label: 'PG', value: 'PG' },
            { label: 'SG', value: 'SG' },
            { label: 'SF', value: 'SF' },
            { label: 'PF', value: 'PF' },
            { label: 'C', value: 'C' }
        ];

        this.tableTypes = [
            { name: "Averages" , value: "Averages"},
            { name: "Totals" , value: "Totals"},
            { name: "Forecasted Averages", value: "ForecastedAVG" },
            { name: "Forecasted Totals", value: "Forecasted" }
        ]

        this.playerStatuses = [
            { label: "All", value: true },
            { label: "Available", value: false }
        ]
    }

    clear(table: Table, searchText: HTMLInputElement) { // this is to make the clear button work on the table
        table.clear();
        searchText.value = '';
    }

    draftPlayer(player: PlayerDto): void {
        this.store.draftPlayer(player)
            .subscribe();
    }

    getEventValue($event:any) :string {
        return $event.target.value;
    }

    onRowUnselect($event: any) { // not implemented
    }

    onRowSelect(event: any) {
        this.store.loadSelectedPlayer(event.data.id).subscribe();
    }

    onTableTypeChange() {
        this.store.setTableType(this.tableType);
        this.store.loadPlayersWithType().subscribe();
    }

    refresh(): void {
        this.store.loadPlayersWithType().subscribe();
    }
}
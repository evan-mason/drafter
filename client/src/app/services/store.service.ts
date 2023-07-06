import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { PlayerDto } from "../shared/PlayerDto";
import { PickDto } from "../shared/PickDto";

@Injectable()
export class Store {

    constructor(private http: HttpClient) {

    }

    public players: PlayerDto[] = [];
    public myPlayers: PlayerDto[] = [];
    //public nextPick: PickDto[] = [];
    public picks: PickDto[] = [];

    loadPlayers(): Observable<void> {
        return this.http.get<[]>("/api/playersview") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.players = data; // set the data we return back into our any array
                return
            }));
    }

    loadMyPlayers(): Observable<void> {
        return this.http.get<[]>("/api/playersview/myteamdashboard") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.myPlayers = data; // set the data we return back into our any array
                return
            }));
    }

    /*loadNextPicks(): Observable<void> {
        return this.http.get<[]>("/api/playersview/nextpickdashboard") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.nextPick = data; // set the data we return back into our any array
                return
            }));
    }*/

    loadPicks(): Observable<void> {
        return this.http.get<[]>("/api/playersview/picksdashboard") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.picks = data; // set the data we return back into our any array
                return
            }));
    }

}
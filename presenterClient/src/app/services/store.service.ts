import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { PlayerDto } from "../shared/PlayerDto";
import { PickDto } from "../shared/PickDto";

@Injectable()
export class Store {

    constructor(private http: HttpClient) {

    }

    public previousPick: any;
    public myPlayers: PlayerDto[] = [];
    public lastPickTime: any;
    //public nextPick: PickDto[] = [];
    public picks: PickDto[] = [];

    loadMyPlayers(): Observable<void> {
        return this.http.get<[]>("/api/presenter/myteamdashboard") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.myPlayers = data; // set the data we return back into our any array
                return
            }));
    }

    loadPicks(): Observable<void> {
        return this.http.get<[]>("/api/presenter/pickspresenter") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.picks = data; // set the data we return back into our any array
                return
            }));
    }

    loadPreviousPick(){ // placeholder for now

        const previousPick: PlayerDto = {
            id: 0,
            name: "Example previous pick",
            position: "",
            nbaTeam: "",
            fantasyPoints: 0,
            fantasyTeam: ""
        }

        this.previousPick = previousPick;
    }

    loadTimer(): Observable<void> {
        return this.http.get<any>("/api/presenter/lastpicktime") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.lastPickTime = new Date(data); // set the data we return back into our any array
            }));
    }
}
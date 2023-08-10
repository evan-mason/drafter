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
    public currentTeamName: string = "";
    public currentTeam: PlayerDto[] = [];
    public lastPickTime: any;
    //public nextPick: PickDto[] = [];
    public picks: PickDto[] = [];
    public totalTeams: number = 0;

    loadTeam(teamNumber: number): Observable<void> {
        let queryParams = new HttpParams().append("id", teamNumber);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.currentTeam = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeamName(teamNumber: number): Observable<void> {
        let queryParams = new HttpParams().append("id", teamNumber);
        return this.http.get<string>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.currentTeamName = data;
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
            id: 5,
            name: "Kyrie",
            position: "C",
            nbaTeam: "mavs",
            fantasyPoints: 20,
            fantasyTeam: "kevy1"
        }

        this.previousPick = previousPick;
    }

    loadTimer(): Observable<void> {
        return this.http.get<any>("/api/presenter/lastpicktime") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.lastPickTime = new Date(data); // set the data we return back into our any array
            }));
    }

    loadTotalTeams(): Observable<void> {
        return this.http.get<number>("/api/presenter/totalTeams") 
            .pipe(map(data => {
                this.totalTeams = data;
            }));
    }
}
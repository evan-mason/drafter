import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { PlayerDto } from "../shared/PlayerDto";
import { PickDto } from "../shared/PickDto";
import { Player } from "../shared/Player";

@Injectable()
export class Store {

    constructor(private http: HttpClient) {
        this.refresh();
    }

    public players: PlayerDto[] = [];
    public myPlayers: PlayerDto[] = [];
    public timeline: PlayerDto[] = [];
    public lastPickTime: any;
    public newPickTime: any;
    public picks: PickDto[] = [];
    public selectedPlayer: any;
    public tableType: any = 'Averages';
    public allPlayers: Boolean = false;

    loadPlayers(): Observable<void> {
        return this.http.get<[]>("/api/playersview/playersaverage") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.players = data; // set the data we return back into our any array
                return
            }));
    }

    loadPlayersWithType(): Observable<void> { // This will get a differing point value for overall table points.
        if (this.tableType === "Totals") {
            if (this.allPlayers === true) {
                return this.http.get<[]>("/api/playersview/playerstotal") // we use a get from the players url we expect, and are saying we expect an array type back
                    .pipe(map(data => {
                        this.players = data; // set the data we return back into our any array
                        return
                    }));
            }
            else {
                return this.http.get<[]>("/api/playersview/freeplayerstotal") // we use a get from the players url we expect, and are saying we expect an array type back
                    .pipe(map(data => {
                        this.players = data; // set the data we return back into our any array
                        return
                    }));
            }
        }
        else if (this.tableType === "ForecastedAVG"){
            if (this.allPlayers === true) {
                return this.http.get<[]>("/api/playersview/playersforecastedaverage") // we use a get from the players url we expect, and are saying we expect an array type back
                    .pipe(map(data => {
                        this.players = data; // set the data we return back into our any array
                        return
                    }));
            }
            else {
                return this.http.get<[]>("/api/playersview/freeplayersforecastedaverage") // we use a get from the players url we expect, and are saying we expect an array type back
                    .pipe(map(data => {
                        this.players = data; // set the data we return back into our any array
                        return
                    }));
            }
        }
        else if (this.tableType === "Forecasted") {
            if (this.allPlayers === true) {
                return this.http.get<[]>("/api/playersview/playersforecastedtotal") // we use a get from the players url we expect, and are saying we expect an array type back
                    .pipe(map(data => {
                        this.players = data; // set the data we return back into our any array
                        return
                    }));
            }
            else {
                return this.http.get<[]>("/api/playersview/freeplayersforecastedtotal") // we use a get from the players url we expect, and are saying we expect an array type back
                    .pipe(map(data => {
                        this.players = data; // set the data we return back into our any array
                        return
                    }));
            }
        }

        else {
            if (this.allPlayers === true) {
                return this.http.get<[]>("/api/playersview/playersaverage") // we use a get from the players url we expect, and are saying we expect an array type back
                    .pipe(map(data => {
                        this.players = data; // set the data we return back into our any array
                        return
                    }));
            }
            else {
                return this.http.get<[]>("/api/playersview/freeplayersaverage") // we use a get from the players url we expect, and are saying we expect an array type back
                    .pipe(map(data => {
                        this.players = data; // set the data we return back into our any array
                        return
                    }));
            }
        }
    }

    loadMyPlayers(): Observable<void> {
        return this.http.get<[]>("/api/playersview/myteamdashboard") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.myPlayers = data; // set the data we return back into our any array
                return
            }));
    }

    loadSelectedPlayer(playerId: number): Observable<void> {
        let queryParams = new HttpParams().append("id", playerId);
        return this.http.get<Player>("/api/playersview/selectedplayer", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.selectedPlayer = data; // set the data we return back into our any array
                //console.log(this.selectedPlayer); // REMOVE ONCE WE REALISE IT WORKS
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

    loadTimeline(): Observable<void> {
        return this.http.get<[]>("/api/playersview/timelinedashboard") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.timeline = data; // set the data we return back into our any array
                return
            }));
    }

    loadTimer(): Observable<void> {
        return this.http.get<any>("/api/playersview/lastpicktime") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.lastPickTime = new Date(data); // set the data we return back into our any array
            }));
    }

    draftPlayer(player: PlayerDto): Observable<void>{
        console.log(player);
        let draftedFreeAgentIndex : number = this.players.findIndex(p => p.id == player.id)!;
        return this.http.post<PlayerDto>("/api/playersview/draftplayerdashboard", player) // we're getting the new player back, this is because we need it's new team.
            .pipe(map(playerDto => {
                this.myPlayers.push(player); // puts the returned player into our list
                this.players[draftedFreeAgentIndex] = playerDto; // puts the returned player into the main list with changed attributes
                this.picks.shift(); // removes the first pick from the list
                this.timeline.push(player); // adds the player to the timeline
                //this.lastPickTime(new Date()); // sets the last pick time to now although it doesn't work. time format is incorrect.
            }));
    }

    refresh(): void { // move logic to presenter when completed
        setInterval(() => { // the following logic didn't work so I will just refresh every 5 seconds for everyone
            /*const oldPickTime = new Date(this.lastPickTime.getTime()); // THIS IS FOR A DEEP COPY, LOOK INTO lodash if we are going to keep doing this type of thing
            this.loadTimer().subscribe();
            const newPickTime = new Date(this.lastPickTime.getTime());
            console.log("Loaded new timer");
            console.log("old timer = " + oldPickTime);
            console.log("new timer = " + newPickTime);
            if (newPickTime !== oldPickTime) {
                console.log("Player was picked in the last 5 seconds!!!!")
                // refresh everything that isn't me
            }*/

            //this.loadPlayersWithType().subscribe();
            this.loadPicks().subscribe();
            this.loadTimeline().subscribe();
            this.loadTimer().subscribe();

        }, 1000);
    }

    setTableType(tableType: string): void {
        this.tableType = tableType;
    }
}
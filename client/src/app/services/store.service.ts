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

    //Draftboard bullshit
    public team1!: any[];
    public team2!: any[];
    public team3!: any[];
    public team4!: any[];
    public team5!: any[];
    public team6!: any[];
    public team7!: any[];
    public team8!: any[];
    public team9!: any[];
    public team10!: any[];

    public team1name!: any[];
    public team2name!: any[];
    public team3name!: any[];
    public team4name!: any[];
    public team5name!: any[];
    public team6name!: any[];
    public team7name!: any[];
    public team8name!: any[];
    public team9name!: any[];
    public team10name!: any[];

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

    // REMOVE BELOW FOR BETTER IMPLEMENTATION
    refreshDraftboard(): void {
        this.loadTeam1().subscribe();
        this.loadTeam2().subscribe();
        this.loadTeam3().subscribe();
        this.loadTeam4().subscribe();
        this.loadTeam5().subscribe();
        this.loadTeam6().subscribe();
        this.loadTeam7().subscribe();
        this.loadTeam8().subscribe();
        this.loadTeam9().subscribe();
        this.loadTeam10().subscribe();
    }

    // REMOVE BELOW FOR BETTER IMPLEMENTATION
    refreshDraftboardName(): void {
        this.loadTeam1Name().subscribe();
        this.loadTeam2Name().subscribe();
        this.loadTeam3Name().subscribe();
        this.loadTeam4Name().subscribe();
        this.loadTeam5Name().subscribe();
        this.loadTeam6Name().subscribe();
        this.loadTeam7Name().subscribe();
        this.loadTeam8Name().subscribe();
        this.loadTeam9Name().subscribe();
        this.loadTeam10Name().subscribe();
    }

    loadTeam1(): Observable<void> {
        let queryParams = new HttpParams().append("id", 1);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team1 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam2(): Observable<void> {
        let queryParams = new HttpParams().append("id", 3);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team2 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam3(): Observable<void> {
        let queryParams = new HttpParams().append("id", 4);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team3 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam4(): Observable<void> {
        let queryParams = new HttpParams().append("id", 5);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team4 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam5(): Observable<void> {
        let queryParams = new HttpParams().append("id", 6);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team5 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam6(): Observable<void> {
        let queryParams = new HttpParams().append("id", 7);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team6 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam7(): Observable<void> {
        let queryParams = new HttpParams().append("id", 8);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team7 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam8(): Observable<void> {
        let queryParams = new HttpParams().append("id", 9);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team8 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam9(): Observable<void> {
        let queryParams = new HttpParams().append("id", 10);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team9 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam10(): Observable<void> {
        let queryParams = new HttpParams().append("id", 11);
        return this.http.get<PlayerDto[]>("/api/presenter/getteampresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team10 = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam1Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 1);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team1name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam2Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 3);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team2name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam3Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 4);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team3name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam4Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 5);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team4name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam5Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 6);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team5name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam6Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 7);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team6name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam7Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 8);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team7name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam8Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 9);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team8name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam9Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 10);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team9name = data; // set the data we return back into our any array
                return
            }));
    }

    loadTeam10Name(): Observable<void> {
        let queryParams = new HttpParams().append("id", 11);
        return this.http.get<PlayerDto[]>("/api/presenter/getteamnamepresenter", { params: queryParams }) // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.team10name = data; // set the data we return back into our any array
                return
            }));
    }

}
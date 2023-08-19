import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
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
    public nextBests: PlayerDto[] = [];
    public lastPickTime: any;
    //public nextPick: PickDto[] = [];
    public picks: PickDto[] = [];
    public totalTeams: number = 0;
    // for viewer
    public currentPage: number = 0;
    public totalPages: number = 6;
    private pageSub$ = new Subject<number>();
    public page$ = this.pageSub$.asObservable();
    

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

    loadNextBests() {
        const nextBests: PlayerDto[] = [
            // generate list of 5 sample PlayerDto's
            {
                id: 1,
                name: "Kyrie",
                position: "C",
                nbaTeam: "mavs",
                fantasyPoints: 20,
                fantasyTeam: "kevy1"
            },
            {
                id: 2,
                name: "Kobe",
                position: "C",
                nbaTeam: "mavs",
                fantasyPoints: 20,
                fantasyTeam: "kevy1"
            },
            {
                id: 3,
                name: "Lebron",
                position: "C",
                nbaTeam: "mavs",
                fantasyPoints: 20,
                fantasyTeam: "kevy1"
            },
            {
                id: 4,
                name: "Kyrie",
                position: "C",
                nbaTeam: "mavs",
                fantasyPoints: 20,
                fantasyTeam: "kevy1"
            },
            {
                id: 5,
                name: "Kyrie",
                position: "C",
                nbaTeam: "mavs",
                fantasyPoints: 20,
                fantasyTeam: "kevy1"
            }
        ]
        this.nextBests = nextBests;
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

    nextPage() { // I can pull this out of here if I like, but I think I'm going to want to emit next from the store in some other area.
        this.currentPage++;
        if (this.currentPage === this.totalPages) { // this is because if 2 is the first team 3 is the second team and so on. total teams is one more than the count.
            this.currentPage = 0;
        }
        this.pageSub$.next(this.currentPage);
    }

    setPage(pageNumber : number) { // unused but might be cool to use somewhere. Could have a secret page 5 or something.
        this.currentPage = pageNumber;
        this.pageSub$.next(this.currentPage);
    }
}
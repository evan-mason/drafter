import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators"
import { PlayerDto } from "../shared/PlayerDto"

@Injectable()
export class Store {

    constructor(private http: HttpClient) {

    }

    public players: PlayerDto[] = [];

    loadPlayers(): Observable<void> {
        return this.http.get<[]>("/api/playersview") // we use a get from the players url we expect, and are saying we expect an array type back
            .pipe(map(data => {
                this.players = data; // set the data we return back into our any array
                return
            }));
    }
}
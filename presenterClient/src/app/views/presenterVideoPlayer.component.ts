import { Component, OnInit} from '@angular/core';
import { VgApiService } from '@videogular/ngx-videogular/core';
import { Store } from '../services/store.service';

@Component({
    selector: 'presenter-video-player',
    templateUrl: "presenterVideoPlayer.component.html",
    styles: []
})
export default class PresenterVideoPlayer implements OnInit{

    preload: string = 'auto';
    api: VgApiService = new VgApiService;

    constructor(public store: Store) { }

    ngOnInit(): void {
        //setTimeout(() => this.videoUrl = 'luka1080', 10000);
        //setTimeout(() => this.videoUrl = 'lebron1080', 30000); // second video will play 30 seconds after window init
    }

    onPlayerReady(api: VgApiService) {
        this.api = api;

        this.playAudio();

        setTimeout(() => this.api.getDefaultMedia().play(), 5000); // 5 seconds after window init, send play.

        setTimeout(() => {
            if (this.api.canPlay != true) {
                this.store.video = false
                console.log("CANNOT PLAY SO RESETTING");
            }
        }, 5100) // 5 seconds after window init, if video can't play, reset videoUrl to false and back to waiting state.

        setTimeout(() => this.store.video = false, 120000); //15 seconds after window init, reset videoUrl to false and back to waiting state.
    }

    playAudio() {
        let audio = new Audio();
        audio.src = "./sounds/draftsound.mp3";
        audio.load();
        audio.play();
    }

    ngAfterViewInit() {
        setInterval(() => {
            this.store.getVideo().subscribe();
        }, 3000); // check for new player every 3 seconds
    }
}
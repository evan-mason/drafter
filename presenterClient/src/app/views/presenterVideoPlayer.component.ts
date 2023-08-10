﻿import { Component, OnInit} from '@angular/core';
import { VgApiService } from '@videogular/ngx-videogular/core';

@Component({
    selector: 'presenter-video-player',
    templateUrl: "presenterVideoPlayer.component.html",
    styles: []
})
export default class PresenterVideoPlayer implements OnInit{

    preload: string = 'auto';
    api: VgApiService = new VgApiService;
    videoUrl: any = false;

    constructor() { }

    ngOnInit(): void {
        setTimeout(() => this.videoUrl = 'luka1080', 10000);
        setTimeout(() => this.videoUrl = 'lebron1080', 30000); // second video will play 30 seconds after window init
    }

    onPlayerReady(api: VgApiService) {
        this.api = api;

        this.playAudio();

        setTimeout(() => this.api.getDefaultMedia().play(), 5000); // 5 seconds after window init, send play.

        setTimeout(() => this.api.getDefaultMedia().pause(), 15000); // 15 seconds after window init send pause

        setTimeout(() => this.videoUrl = false, 15000); //15 seconds after window init, reset videoUrl to false and back to waiting state.
    }

    playAudio() {
        let audio = new Audio();
        audio.src = "./sounds/draftsound.mp3";
        audio.load();
        audio.play();
    }
}
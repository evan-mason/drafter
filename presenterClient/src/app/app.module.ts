import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card'; // FOR DASHBOARD PICKS
import { TableModule } from 'primeng/table';

//For Video Functionality
import { VgCoreModule } from '@videogular/ngx-videogular/core';
import { VgControlsModule } from '@videogular/ngx-videogular/controls';
import { VgOverlayPlayModule } from '@videogular/ngx-videogular/overlay-play';
import { VgBufferingModule } from '@videogular/ngx-videogular/buffering';

import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import PresenterPickView from './views/presenterPickView.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import PresenterTime from './views/presenterTime.component';
import PresenterVideoPlayer from './views/presenterVideoPlayer.component';
import AllTeamsView from './views/allTeamsView.component';
import PresenterLastPick from './views/presenterLastPick.component';
import PresenterNextBests from './views/presenterNextBests.component';
import presenterViewer from './views/presenterViewer.component';

@NgModule({
  declarations: [
        AppComponent,
        AllTeamsView,
        PresenterPickView,
        PresenterTime,
        PresenterVideoPlayer,
        PresenterLastPick,
        PresenterNextBests,
        presenterViewer
  ],
  imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule, // used in position filter for table module.
        TableModule,
        MatCardModule,
        BrowserAnimationsModule,

        // For Videos
        VgCoreModule,
        VgControlsModule,
        VgOverlayPlayModule,
        VgBufferingModule
  ],
  providers: [Store],
  bootstrap: [AppComponent]
})
export class AppModule { }

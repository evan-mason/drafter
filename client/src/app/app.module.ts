import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card'; // FOR DASHBOARD PICKS
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { SelectButtonModule } from 'primeng/selectbutton';
import { RatingModule } from 'primeng/rating';

import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import PlayerPickerView from './views/playerPickerView.component';
import MyTeamView from './views/myTeamView.component';
import DashboardPickView from './views/dashboardPickView.component';
import DashboardTimelineView from './views/dashboardTimelineView.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import DashboardTime from './views/dashboardTime.component';
import DashboardSelectedPlayer from './views/dashboardSelectedPlayer.component';
import { ReversePipe } from './pipes/reversePipe';

@NgModule({
  declarations: [
        AppComponent,
        PlayerPickerView,
        MyTeamView,
        DashboardPickView,
        DashboardTimelineView,
        DashboardTime,
        DashboardSelectedPlayer,
        ReversePipe
  ],
  imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule, // used in position filter for table module.
        TableModule,
        DropdownModule,
        TagModule,
        ButtonModule,
        InputTextModule,
        MatCardModule,
        BrowserAnimationsModule,
        SelectButtonModule,
        RatingModule
  ],
  providers: [Store],
  bootstrap: [AppComponent]
})
export class AppModule { }

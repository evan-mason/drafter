import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { TagModule } from 'primeng/tag';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';

import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import PlayerPickerView from './views/playerPickerView.component';
import MyTeamView from './views/myTeamView.component';
import DashboardPickView from './views/dashboardPickView.component';
import DashboardTimelineView from './views/dashboardTimelineView.component';

@NgModule({
  declarations: [
        AppComponent,
        PlayerPickerView,
        MyTeamView,
        DashboardPickView,
        DashboardTimelineView
  ],
  imports: [
        BrowserModule,
        HttpClientModule,
        FormsModule, // used in position filter for table module.
        TableModule,
        DropdownModule,
        TagModule,
        ButtonModule,
        InputTextModule
  ],
  providers: [Store],
  bootstrap: [AppComponent]
})
export class AppModule { }

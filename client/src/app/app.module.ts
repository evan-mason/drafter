import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { Store } from './services/store.service';
import PlayerPickerView from './views/playerPickerView.component';
import MyTeamView from './views/myTeamView.component';

@NgModule({
  declarations: [
        AppComponent,
        PlayerPickerView,
        MyTeamView
  ],
  imports: [
        BrowserModule,
        HttpClientModule
  ],
  providers: [Store],
  bootstrap: [AppComponent]
})
export class AppModule { }

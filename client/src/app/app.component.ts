import { Component } from '@angular/core';

@Component({ // the template needs to be converted to a html template
  selector: 'dashboard',
  template: `<player-picker></player-picker>`, 
  styles: []
})
export class AppComponent {
  title = 'Dashboard';
}

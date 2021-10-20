import { Component } from '@angular/core';
import { faCalendar } from '@fortawesome/free-regular-svg-icons'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})

export class AppComponent {
  title = 'Comentarios';
  calendar = faCalendar;
}

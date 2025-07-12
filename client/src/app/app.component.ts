import { Component } from '@angular/core'
import { RouterOutlet } from '@angular/router'

@Component({
  host: { class: 'block min-h-screen bg-gray-100' },
  selector: 'app-root',
  imports: [RouterOutlet],
  template: ` <router-outlet /> `,
})
export class AppComponent {}

import { Routes } from '@angular/router'

export const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('@features/todos/todos.routes').then((m) => m.routes),
  },
]

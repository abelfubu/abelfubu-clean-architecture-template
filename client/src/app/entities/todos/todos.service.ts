import { HttpClient } from '@angular/common/http'
import { inject, Injectable } from '@angular/core'
import { map, Observable } from 'rxjs'
import { ConfigurationStore } from '../../core/configuration/configuration.store'
import { TodoDto } from './models/todo.dto'
import { Todo } from './models/todo.model'

@Injectable({
  providedIn: 'root',
})
export class TodosService {
  private readonly http = inject(HttpClient)
  private readonly config = inject(ConfigurationStore)

  getAll() {
    return this.http
      .get<TodoDto[]>(`${this.config.get((c) => c.apiUrl)}/todos`)
      .pipe(
        map((todos) =>
          todos.map((todo) => ({ ...todo, dateTime: new Date(todo.dateTime) })),
        ),
      )
  }

  add(todoRequest: {
    description: string
    priority: number
  }): Observable<Todo> {
    return this.http.post<Todo>(
      `${this.config.get((c) => c.apiUrl)}/todos`,
      todoRequest,
    )
  }

  update(todo: Todo): Observable<void> {
    return this.http.put<void>(
      `${this.config.get((c) => c.apiUrl)}/todos/${todo.id}`,
      todo,
    )
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(
      `${this.config.get((c) => c.apiUrl)}/todos/${id}`,
    )
  }
}

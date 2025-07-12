import { inject, Injectable } from '@angular/core'
import { Todo } from '@entities/todos/models/todo.model'
import { TodosService } from '@entities/todos/todos.service'
import { map, Observable } from 'rxjs'
import { todosAdapter } from './adapters/todos.adapter'

@Injectable({
  providedIn: 'root',
})
export class TodosFacade {
  private readonly todos = inject(TodosService)

  get(): Observable<Record<string, Todo>> {
    return this.todos.getAll().pipe(map(todosAdapter))
  }

  add(description: string): Observable<Todo> {
    return this.todos.add({
      description,
      priority: 0,
    })
  }

  update(todo: Todo): Observable<void> {
    return this.todos.update(todo)
  }

  delete(id: string) {
    return this.todos.delete(id)
  }
}

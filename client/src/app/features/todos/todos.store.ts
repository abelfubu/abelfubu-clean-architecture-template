import { Injectable, computed, inject, signal } from '@angular/core'

import { Todo } from '@entities/todos/models/todo.model'
import { TodosFacade } from './todos.facade'

interface TodosState {
  todos: Record<string, Todo>
}

@Injectable({
  providedIn: 'root',
})
export class TodosStore {
  private readonly facade = inject(TodosFacade)

  private readonly state = signal<TodosState>({ todos: {} })

  readonly todos = computed(() => Object.values(this.state().todos))

  initialize(): void {
    this.facade.get().subscribe((todos) => this.state.set({ todos }))
  }

  addTodo(description: string) {
    if (!description) return

    this.facade.add(description).subscribe((todo) => {
      this.state.update((state) => ({
        ...state,
        todos: {
          ...state.todos,
          [todo.id]: structuredClone(todo),
        },
      }))
    })
  }

  toggleTodo(todo: Todo): void {
    const todoUpdated = {
      ...todo,
      isCompleted: !todo.isCompleted,
    }

    this.facade.update(todoUpdated).subscribe(() => {
      this.state.update((state) => {
        state.todos[todo.id] = todoUpdated
        return structuredClone(state)
      })
    })
  }

  remove(id: string) {
    this.facade.delete(id).subscribe(() => {
      this.state.update((state) => {
        const { [id]: _, ...remainingTodos } = state.todos
        return { ...state, todos: remainingTodos }
      })
    })
  }
}

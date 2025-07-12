import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit,
} from '@angular/core'
import { TodosStore } from './todos.store'

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: { class: 'flex flex-col min-h-screen p-8' },
  providers: [TodosStore],
  selector: 'app-todos',
  template: `
    <section
      class="flex flex-col gap-8 bg-white p-8 rounded-lg shadow-lg flex-1 w-3xl mx-auto"
    >
      <h1 class="text-7xl">Todos</h1>

      <div class="card flex gap-3">
        <input
          type="text"
          placeholder="Add a new todo"
          class="input input-bordered w-full py-2 px-4 border border-gray-300 rounded"
          #todoInput
        />
        <button
          class="bg-blue-400 text-white py-2 px-4 rounded"
          (click)="store.addTodo(todoInput.value); todoInput.select()"
        >
          Add
        </button>
      </div>

      <div class="flex flex-col gap-4">
        @for (todo of store.todos(); track todo.id) {
          <div class="flex gap-4 items-center">
            <input
              type="checkbox"
              [checked]="todo.isCompleted"
              (input)="store.toggleTodo(todo)"
              class="scale-150 translate-0.5"
            />

            <div class="text-2xl flex-1">{{ todo.description }}</div>

            <div (click)="store.remove(todo.id)" class="cursor-pointer">🗑️</div>
          </div>
        }
      </div>
    </section>
  `,
})
export class TodosComponent implements OnInit {
  protected readonly store = inject(TodosStore)

  ngOnInit(): void {
    this.store.initialize()
  }
}

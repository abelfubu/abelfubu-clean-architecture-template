import { Todo } from '@entities/todos/models/todo.model'

export function todosAdapter(source: Todo[]): Record<string, Todo> {
  return source.reduce<Record<string, Todo>>(
    (total, todo) => ({ ...total, [todo.id]: todo }),
    {},
  )
}

import { TestBed } from '@angular/core/testing'

import { TodosFacade } from './todos.facade'

describe(TodosFacade.name, () => {
  const TodosMock = {
    getAll: jest.fn(),
  }

  afterEach(() => jest.clearAllMocks())

  function setup() {
    TestBed.configureTestingModule({
      providers: [{ provide: TodosFacade, useValue: TodosMock }],
    })

    return {
      facade: TestBed.inject(TodosFacade),
    }
  }

  it('should get', () => {
    const { facade } = setup()

    facade.get()

    expect(TodosMock.getAll).toHaveBeenCalled()
  })
})

import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';

import { TodosFacade } from './todos.facade';
import { TodosStore } from './todos.store';

describe(TodosStore.name, () => {
  const FacadeMock = {
    get: jest.fn(),
  };

  afterEach(() => jest.clearAllMocks());

  function setup() {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: TodosFacade,
          useValue: FacadeMock,
        },
      ],
    });

    return { 
      store: TestBed.inject(TodosStore) 
    };
  }

  it('should initialize', () => {
    const { store } = setup();

    FacadeMock.get.mockReturnValue(of({ name: 'Todos' }));
    store.initialize();
    expect(store.name()).toBe('Todos');
  });
});
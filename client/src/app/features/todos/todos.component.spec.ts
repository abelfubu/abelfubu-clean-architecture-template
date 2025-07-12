import { signal } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { TodosComponent } from './todos.component';
import { TodosStore } from './todos.store';

describe(TodosComponent.name, () => {
  const StoreMock = {
    initialize: jest.fn(),
    name: signal('Todos'),
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TodosComponent],
      providers: [
        {
          provide: TodosStore,
          useValue: StoreMock,
        },
      ],
    }).compileComponents();
  });

  function setup() {
    const fixture = TestBed.createComponent(TodosComponent);
    fixture.detectChanges();

    return { fixture };
  }

  it('should initialize store', () => {
    setup();

    expect(StoreMock.initialize).toHaveBeenCalled();
  });
});
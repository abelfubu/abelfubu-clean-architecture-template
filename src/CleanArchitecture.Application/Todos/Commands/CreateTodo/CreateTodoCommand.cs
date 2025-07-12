using CleanArchitecture.Domain.Todos;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Commands.CreateTodo;

public record CreateTodoCommand(
    string Description,
    DateTime? DueDate,
    int Priority) : IRequest<ErrorOr<Todo>>;
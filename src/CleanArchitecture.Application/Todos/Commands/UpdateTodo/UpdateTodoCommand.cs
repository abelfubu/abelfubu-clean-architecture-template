using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Commands.UpdateTodo;

public record UpdateTodoCommand(
    Guid Id,
    string Description,
    bool IsCompleted,
    int Priority,
    DateTime DueDate) : IRequest<ErrorOr<Guid>>;
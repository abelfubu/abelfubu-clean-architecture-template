using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Commands.DeleteTodo;

public sealed record DeleteTodoCommand(Guid Id) : IRequest<ErrorOr<bool>>;
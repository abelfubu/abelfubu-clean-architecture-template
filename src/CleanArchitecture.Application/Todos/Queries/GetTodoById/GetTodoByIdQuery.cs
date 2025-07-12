using CleanArchitecture.Domain.Todos;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Queries.GetTodoById;

public sealed record GetTodoByIdQuery(Guid Id) : IRequest<ErrorOr<Todo>>;
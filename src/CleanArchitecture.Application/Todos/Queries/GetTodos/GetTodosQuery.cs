using CleanArchitecture.Domain.Todos;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Queries.GetTodos;

public record GetTodosQuery : IRequest<ErrorOr<List<Todo>>>;
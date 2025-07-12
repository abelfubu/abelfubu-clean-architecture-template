using CleanArchitecture.Domain.Common.Persistence;
using CleanArchitecture.Domain.Todos;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Queries.GetTodos;

internal sealed class GetTodosQueryHandler(ITodosRepository repository)
    : IRequestHandler<GetTodosQuery, ErrorOr<List<Todo>>>
{
    public async Task<ErrorOr<List<Todo>>> Handle(
        GetTodosQuery request,
        CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}
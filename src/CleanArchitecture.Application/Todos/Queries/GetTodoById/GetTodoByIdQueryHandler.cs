using CleanArchitecture.Domain.Common.Persistence;
using CleanArchitecture.Domain.Todos;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Queries.GetTodoById;

internal sealed class GetTodoByIdQueryHandler(ITodosRepository todosRepository)
    : IRequestHandler<GetTodoByIdQuery, ErrorOr<Todo>>
{
    public async Task<ErrorOr<Todo>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await todosRepository.GetByIdAsync(request.Id, cancellationToken);

        return todo is not null
            ? todo
            : Error.NotFound($"Todo with ID {request.Id} not found.");
    }
}
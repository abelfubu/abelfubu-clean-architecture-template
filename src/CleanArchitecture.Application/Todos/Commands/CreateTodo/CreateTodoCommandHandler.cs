using CleanArchitecture.Domain.Common.Persistence;
using CleanArchitecture.Domain.Todos;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Commands.CreateTodo;

internal sealed class CreateTodoCommandHandler(
    ITodosRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateTodoCommand, ErrorOr<Todo>>
{
    public async Task<ErrorOr<Todo>> Handle(
        CreateTodoCommand request,
        CancellationToken cancellationToken)
    {
        var todo = Todo.Create(request.Description, request.DueDate, request.Priority);

        await repository.AddAsync(todo, cancellationToken);
        await unitOfWork.CommitChangesAsync(cancellationToken);

        return todo;
    }
}
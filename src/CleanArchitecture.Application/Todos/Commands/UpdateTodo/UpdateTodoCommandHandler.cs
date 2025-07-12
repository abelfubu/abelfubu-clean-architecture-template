using CleanArchitecture.Domain.Common.Persistence;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Commands.UpdateTodo;

internal sealed class UpdateTodoCommandHandler(
    ITodosRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateTodoCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(
        UpdateTodoCommand request,
        CancellationToken cancellationToken)
    {
        var todo = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (todo is null)
        {
            return Error.NotFound();
        }

        todo.Update(request.Description, DateTime.Now, request.Priority, request.IsCompleted);

        repository.Update(todo);

        await unitOfWork.CommitChangesAsync(cancellationToken);

        return todo.Id;
    }
}
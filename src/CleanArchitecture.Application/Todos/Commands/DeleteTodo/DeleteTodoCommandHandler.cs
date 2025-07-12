using CleanArchitecture.Domain.Common.Persistence;

using ErrorOr;

using MediatR;

namespace CleanArchitecture.Application.Todos.Commands.DeleteTodo;

internal sealed class DeleteTodoCommandHandler(ITodosRepository todosRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteTodoCommand, ErrorOr<bool>>
{
    public async Task<ErrorOr<bool>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await todosRepository.GetByIdAsync(request.Id, cancellationToken);

        if (todo is null)
        {
            return Error.NotFound();
        }

        todosRepository.Remove(todo);

        await unitOfWork.CommitChangesAsync(cancellationToken);

        return true;
    }
}
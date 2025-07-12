using CleanArchitecture.Application.Todos.Commands.DeleteTodo;

using MediatR;

namespace CleanArchitecture.Api.Endpoints.Todos;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder router)
    {
        router.MapDelete("todos/{id:guid}", async (
            Guid id,
            ISender mediatr,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteTodoCommand(id);
            var result = await mediatr.Send(command, cancellationToken);

            return result.Match(
                Results.Ok,
                (errors) => Results.Problem(errors.First().Description));
        })
        .WithTags(Tags.Todos)
        .WithName(TodosEndpoints.Delete);
    }
}

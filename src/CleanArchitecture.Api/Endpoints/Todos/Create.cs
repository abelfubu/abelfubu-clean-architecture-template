using CleanArchitecture.Application.Todos.Commands.CreateTodo;

using MediatR;

namespace CleanArchitecture.Api.Endpoints.Todos;

internal sealed class Create : IEndpoint
{
    public sealed class Request
    {
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder router)
    {
        router.MapPost("todos", async (
            Request request,
            ISender mediatr,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateTodoCommand(
                request.Description,
                request.DueDate,
                request.Priority);

            var result = await mediatr.Send(command, cancellationToken);

            return result.Match(
                todo => Results.CreatedAtRoute(routeName: TodosEndpoints.GetById, routeValues: new { id = todo.Id }, todo),
                (errors) => Results.Problem(errors.First().Description));
        })
        .WithTags(Tags.Todos)
        .WithName(TodosEndpoints.Create);
    }
}

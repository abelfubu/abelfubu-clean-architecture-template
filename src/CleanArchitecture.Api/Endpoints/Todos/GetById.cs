using CleanArchitecture.Application.Todos.Queries.GetTodoById;

using MediatR;

namespace CleanArchitecture.Api.Endpoints.Todos;

internal sealed class GetById : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder router)
    {
        router.MapGet("todos/{id:guid}", async (ISender mediatr, Guid id) =>
        {
            var query = new GetTodoByIdQuery(id);

            var result = await mediatr.Send(query);

            return result.Match(
                Results.Ok,
                errors => Results.Problem(detail: errors.First().Description, statusCode: 500));
        })
        .WithTags(Tags.Todos)
        .WithName(TodosEndpoints.GetById);
    }
}

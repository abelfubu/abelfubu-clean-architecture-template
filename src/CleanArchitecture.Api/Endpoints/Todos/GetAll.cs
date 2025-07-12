using CleanArchitecture.Application.Todos.Queries.GetTodos;

using MediatR;

namespace CleanArchitecture.Api.Endpoints.Todos;

internal sealed class GetAll : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder router)
    {
        router.MapGet("todos", async (ISender mediatr) =>
        {
            var query = new GetTodosQuery();

            var result = await mediatr.Send(query);

            return result.Match(
                Results.Ok,
                errors => Results.Problem(detail: errors.First().Description, statusCode: 500));
        }).WithTags(Tags.Todos)
        .WithName(TodosEndpoints.GetAll);
    }
}

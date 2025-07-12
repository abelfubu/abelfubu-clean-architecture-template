using CleanArchitecture.Application.Todos.Commands.UpdateTodo;

using MediatR;

namespace CleanArchitecture.Api.Endpoints.Todos;

internal sealed class Update : IEndpoint
{
    public sealed class UpdateRequest
    {
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder router)
    {
        router.MapPut("todos/{id:Guid}", async (
            Guid id,
            UpdateRequest request,
            ISender mediatr,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateTodoCommand(
                Id: id,
                Description: request.Description,
                IsCompleted: request.IsCompleted,
                Priority: request.Priority,
                DueDate: request.DueDate ?? DateTime.Now.AddDays(1));

            var result = await mediatr.Send(command, cancellationToken);

            return result.Match(Results.Ok, (errors) => Results.Problem(errors.First().Description));
        })
        .WithName(TodosEndpoints.Update)
        .WithTags(Tags.Todos);
    }
}

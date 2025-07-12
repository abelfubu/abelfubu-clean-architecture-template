using CleanArchitecture.Domain.Todos;

namespace CleanArchitecture.Domain.Common.Persistence;

public interface ITodosRepository
{
    Task AddAsync(Todo todo, CancellationToken cancellationToken);
    Task<Todo?> GetByIdAsync(Guid todoId, CancellationToken cancellationToken);
    Task<List<Todo>> GetAllAsync(CancellationToken cancellationToken);
    void Update(Todo todo);
    void Remove(Todo todo);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
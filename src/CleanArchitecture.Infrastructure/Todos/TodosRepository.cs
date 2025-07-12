using CleanArchitecture.Domain.Common.Persistence;
using CleanArchitecture.Domain.Todos;
using CleanArchitecture.Infrastructure.Common.Persistence;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Todos;

public class TodosRepository(AppDbContext _dbContext) : ITodosRepository
{
    public async Task AddAsync(Todo todo, CancellationToken cancellationToken)
        => await _dbContext.AddAsync(todo, cancellationToken);

    public async Task<Todo?> GetByIdAsync(Guid todoId, CancellationToken cancellationToken)
        => await _dbContext.Todos.FindAsync([todoId], cancellationToken);

    public async Task<List<Todo>> GetAllAsync(CancellationToken cancellationToken)
        => await _dbContext.Todos.ToListAsync(cancellationToken);

    public void Update(Todo todo) => _dbContext.Update(todo);

    public void Remove(Todo todo) => _dbContext.Remove(todo);

    public async Task SaveChangesAsync(CancellationToken cancellationToken) =>
        await _dbContext.SaveChangesAsync(cancellationToken);
}
namespace CleanArchitecture.Domain.Common.Persistence;

public interface IUnitOfWork
{
    Task CommitChangesAsync(CancellationToken cancellationToken);
}
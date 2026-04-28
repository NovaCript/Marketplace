namespace Catalog.Infrastructure.Repositories;

public class UnitOfWork(IDocumentSession documentSession) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        await documentSession.SaveChangesAsync(token: cancellationToken);
        return 1;
    }
}
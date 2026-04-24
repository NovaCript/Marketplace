using Catalog.Domain.Entities;

namespace Catalog.Domain.Repository;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken);
}
using Catalog.Domain.Entities;

namespace Catalog.Domain.Repository;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken);
}
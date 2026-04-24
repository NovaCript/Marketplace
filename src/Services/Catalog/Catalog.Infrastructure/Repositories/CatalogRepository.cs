using Catalog.Domain.Entities;
using Catalog.Domain.Repository;
using Marten;

namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository(IDocumentSession documentSession)
    : IBrandRepository,
    ICategoryRepository,
    ICatalogItemRepository
{
    public async Task<IEnumerable<Brand>> GetAllBrandsAsync(CancellationToken cancellationToken)
    {
        return await documentSession.Query<Brand>().ToListAsync(token: cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        return await documentSession.Query<Category>().ToListAsync(token: cancellationToken);
    }

    public async Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken cancellationToken)
    {
        return await documentSession.Query<CatalogItem>().ToListAsync(token: cancellationToken);
    }

    public async Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        return await documentSession.LoadAsync<CatalogItem>(id, cancellationToken);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken cancellationToken)
    {
        return await documentSession.Query<CatalogItem>()
            .Where(ci => 
                !String.IsNullOrEmpty(ci.Title) && 
                ci.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            .ToListAsync(token: cancellationToken);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellationToken)
    {
            return await documentSession.Query<CatalogItem>()
                .Where(ci =>
                    ci.Brand != null &&
                    !String.IsNullOrEmpty(ci.Brand.Title) &&
                    ci.Brand.Title.Contains(brandTitle,
                        StringComparison.OrdinalIgnoreCase))
                .ToListAsync(token: cancellationToken);
    }
    
    public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken cancellationToken)
    {
        documentSession.Store(item);
        await documentSession.SaveChangesAsync(cancellationToken);
        return item;
    }

    public async Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellationToken)
    {
        documentSession.Delete<CatalogItem>(id);
        await documentSession.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateCatalogItemAsinc(CatalogItem item,
        CancellationToken cancellationToken)
    {
        documentSession.Store(item);
        await documentSession.SaveChangesAsync(token: cancellationToken);
        return true;
    }
}
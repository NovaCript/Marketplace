using Catalog.Domain.Specification;
using Marten.Linq;

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

    public async Task<Pagination<CatalogItem>> GetCatalogItemsAsync(QueryArgs queryArgs, CancellationToken cancellationToken)
    {
        
        var allItems = documentSession.Query<CatalogItem>().AsQueryable();
        var brandId = queryArgs.BrandId;
        var categoryId = queryArgs.CategoryId;
        var search = queryArgs.Search;
        var sortString = queryArgs.Sort;
        
        if (brandId is not null)
        {
            allItems = allItems.Where(ci =>
                ci.Brand != null
                && ci.Brand.Id == brandId);
        }

        if (categoryId is not null)
        {
            allItems = allItems.Where(ci => 
                ci.Category != null
                && ci.Category.Id == categoryId);
        }

        if (!string.IsNullOrEmpty(search))
        {
            allItems = allItems.Where(ci =>
                ci.Title != null
                && ci.Title.Contains(search,
                    StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(sortString))
        {
            allItems = sortString.ToLower() switch
            {
                "price_desc" => allItems.OrderByDescending(ci => ci.Price),
                "price_asc" => allItems.OrderBy(ci => ci.Price),
                "title_desc" => allItems.OrderByDescending(ci => ci.Title),
                "title_asc" => allItems.OrderBy(ci => ci.Title),
                _ => allItems
            };
        }

        var count = await allItems.CountAsync(token: cancellationToken);

        var items = await allItems
            .Skip((queryArgs.PageIndex - 1) * queryArgs.PageSize)
            .Take(queryArgs.PageSize)
            .ToListAsync(token: cancellationToken);

        return new Pagination<CatalogItem>(
            PageIndex: queryArgs.PageIndex,
            PageSize: queryArgs.PageSize,
            TotalCount: count,
            Items: items
        );
    }
}
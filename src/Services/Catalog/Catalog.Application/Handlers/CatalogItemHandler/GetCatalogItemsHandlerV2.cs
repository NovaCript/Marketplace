using Catalog.Domain.Specification;

namespace Catalog.Application.Handlers.CatalogItemHandler;

public class GetCatalogItemsHandlerV2(
    ICatalogItemRepository catalogItemRepository) 
    : IRequestHandler<GetCatalogItemsQueryV2, GetCatalogItemsResultV2>
{
    public async Task<GetCatalogItemsResultV2> Handle(
        GetCatalogItemsQueryV2 query,
        CancellationToken cancellationToken)
    {
        var allItems = 
            await catalogItemRepository.GetAllCatalogItemsAsync
                (cancellationToken: cancellationToken);

        var brandId = query.Args.BrandId;
        if (brandId is not null)
        {
            allItems = allItems.Where(ci => ci.Brand?.Id == brandId);
        }

        var categoryId = query.Args.CategoryId;
        if (categoryId is not null)
        {
            allItems = allItems.Where(ci => ci.Category?.Id == categoryId);
        }

        var search = query.Args.Search;
        if (!string.IsNullOrEmpty(search))
        {
            allItems = allItems.Where(ci => 
                    ci.Title != null 
                    && ci.Title.Contains(
                        search,
                        StringComparison.OrdinalIgnoreCase)
                    );
        }

        if (!string.IsNullOrEmpty(query.Args.Sort))
        {
            allItems = query.Args.Sort.ToLower() switch
            {
                "price_desc" => allItems.OrderByDescending(ci => ci.Price),
                "price_asc" => allItems.OrderBy(ci => ci.Price),
                "title_desc" => allItems.OrderByDescending(ci => ci.Title),
                "title_asc" => allItems.OrderBy(ci => ci.Title),
                _ => allItems
            };
        }
        
        var count = allItems.Count();
        var items = allItems
            .Skip((query.Args.PageIndex - 1) * query.Args.PageSize)
            .Take(query.Args.PageSize)
            .ToList();
        var pagination = new Pagination<CatalogItem>(
            PageSize: query.Args.PageSize,
            PageIndex: query.Args.PageIndex,
            TotalCount: count,
            Items: items
        );
        return new GetCatalogItemsResultV2(pagination);
    }
}
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
        var count = allItems.Count();
        var items = allItems
            .Skip((query.PageIndex - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToList();
        var pagination = new Pagination<CatalogItem>(
            PageSize: query.PageSize,
            PageIndex: query.PageIndex,
            TotalCount: count,
            Items: items
        );
        return new GetCatalogItemsResultV2(pagination);
    }
}
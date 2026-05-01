namespace Catalog.Application.Handlers.CatalogItemHandler;

public class GetCatalogItemsByBrandTitleQueryHandler(
    ICatalogItemRepository catalogItemRepository)
: IRequestHandler<GetCatalogItemsByBrandTitleQuery, GetCatalogItemsByBrandTitleResult>
{
    public async Task<GetCatalogItemsByBrandTitleResult> Handle(
        GetCatalogItemsByBrandTitleQuery query,
        CancellationToken cancellationToken)
    {
        IEnumerable<CatalogItem> catalogItems =
            await catalogItemRepository.GetCatalogItemsByBrandAsync(
                query.BrandTitle, cancellationToken: cancellationToken);
        var result = new GetCatalogItemsByBrandTitleResult(catalogItems);
        return result;
    }
}
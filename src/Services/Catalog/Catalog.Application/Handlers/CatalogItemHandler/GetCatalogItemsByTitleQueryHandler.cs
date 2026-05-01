namespace Catalog.Application.Handlers.CatalogItemHandler;

public class GetCatalogItemsByTitleQueryHandler(
    ICatalogItemRepository catalogItemRepository)
: IRequestHandler<GetCatalogItemsByTitleQuery, GetCatalogItemsByTitleResult>
{
    public async Task<GetCatalogItemsByTitleResult> Handle(
        GetCatalogItemsByTitleQuery query,
        CancellationToken cancellationToken)
    {
        IEnumerable<CatalogItem> catalogItems =
            await catalogItemRepository.GetCatalogItemsByTitleAsync(
                query.Title, cancellationToken: cancellationToken);
        GetCatalogItemsByTitleResult result =
            new GetCatalogItemsByTitleResult(catalogItems);
        return result;
    }
}
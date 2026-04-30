namespace Catalog.Application.Handlers.CatalogItemHandler;

public class GetCatalogItemsHandler(
    ICatalogItemRepository catalogItemRepository) 
    : IRequestHandler<GetCatalogItemsQuery, GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(
        GetCatalogItemsQuery request,
        CancellationToken cancellationToken)
    {
        IEnumerable<CatalogItem> catalogItems =
            await catalogItemRepository.GetAllCatalogItemsAsync(
                cancellationToken: cancellationToken);
        GetCatalogItemsResult result = new GetCatalogItemsResult(catalogItems);
        return result;
    }
}
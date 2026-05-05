namespace Catalog.Application.Handlers.CatalogItemHandler;

public class GetCatalogItemByIdQueryHandler(
    ICatalogItemRepository catalogItemRepository) 
    : IRequestHandler<GetCatalogItemByIdQuery
        , GetCatalogItemByIdResult>
{
    public async Task<GetCatalogItemByIdResult> Handle(
        GetCatalogItemByIdQuery query,
        CancellationToken cancellationToken)
    {
        var catalogItem =
            await catalogItemRepository.GetCatalogItemAsync(query.Id,
                cancellationToken: cancellationToken);
        var result = new GetCatalogItemByIdResult(catalogItem);
        return result;
    }
}
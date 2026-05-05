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
        var pagination = await catalogItemRepository.GetCatalogItemsAsync(
            query.Args,
            cancellationToken: cancellationToken);
        return new GetCatalogItemsResultV2(pagination);
    }
}
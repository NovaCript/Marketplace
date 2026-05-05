namespace Catalog.Application.Queries.CatalogItemsQueries;

public record GetCatalogItemsQueryV2(
    int PageIndex, int PageSize) 
    : IRequest<GetCatalogItemsResultV2>;
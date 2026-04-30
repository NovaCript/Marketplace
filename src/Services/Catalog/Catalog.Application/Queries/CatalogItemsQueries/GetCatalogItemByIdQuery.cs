namespace Catalog.Application.Queries.CatalogItemsQueries;

public record GetCatalogItemByIdQuery(Guid id) 
    : IRequest<GetCatalogItemByIdResult>;
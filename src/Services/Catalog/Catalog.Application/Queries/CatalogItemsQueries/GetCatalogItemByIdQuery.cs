namespace Catalog.Application.Queries.CatalogItemsQueries;

public record GetCatalogItemByIdQuery(Guid Id) 
    : IRequest<GetCatalogItemByIdResult>;
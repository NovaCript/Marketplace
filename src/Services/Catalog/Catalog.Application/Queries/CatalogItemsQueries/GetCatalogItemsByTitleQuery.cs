namespace Catalog.Application.Queries.CatalogItemsQueries;

public record GetCatalogItemsByTitleQuery(string Title) : IRequest<GetCatalogItemsByTitleResult>;
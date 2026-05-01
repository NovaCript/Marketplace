namespace Catalog.Application.Queries.CatalogItemsQueries;

public record GetCatalogItemsByBrandTitleQuery(string BrandTitle) : IRequest<GetCatalogItemsByBrandTitleResult>;
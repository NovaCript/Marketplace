using Catalog.Domain.Specification;

namespace Catalog.Application.Queries.CatalogItemsQueries;

public record GetCatalogItemsQueryV2(QueryArgs Args) 
    : IRequest<GetCatalogItemsResultV2>;
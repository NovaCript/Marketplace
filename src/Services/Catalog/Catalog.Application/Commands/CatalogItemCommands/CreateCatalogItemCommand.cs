using Catalog.Application.Dto.CatalogItemDto;

namespace Catalog.Application.Commands.CatalogItemCommands;

public record CreateCatalogItemCommand(
    CreateCatalogItemDto CatalogItemDto
    ) : IRequest<CreateCatalogItemResult>;
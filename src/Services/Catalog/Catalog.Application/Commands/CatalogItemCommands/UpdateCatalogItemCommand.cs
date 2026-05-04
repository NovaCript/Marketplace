using Catalog.Application.Dto.CatalogItemDto;

namespace Catalog.Application.Commands.CatalogItemCommands;

public record UpdateCatalogItemCommand(
    UpdateCatalogItemDto UpdateCatalogItemDto)
    : IRequest<UpdateCatalogItemResult>;
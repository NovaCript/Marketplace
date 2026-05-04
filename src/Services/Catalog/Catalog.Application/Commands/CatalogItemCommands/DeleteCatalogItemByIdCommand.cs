using Catalog.Application.Dto.CatalogItemDto;

namespace Catalog.Application.Commands.CatalogItemCommands;

public record DeleteCatalogItemByIdCommand(Guid Id) 
    : IRequest<DeleteCatalogItemByIdResult>;
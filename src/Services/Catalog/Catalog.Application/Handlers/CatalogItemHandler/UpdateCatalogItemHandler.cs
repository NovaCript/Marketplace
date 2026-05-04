using Catalog.Application.Commands.CatalogItemCommands;
using Mapster;

namespace Catalog.Application.Handlers.CatalogItemHandler;

public class UpdateCatalogItemHandler(
    ICatalogItemRepository catalogItemRepository) 
    : IRequestHandler<UpdateCatalogItemCommand, UpdateCatalogItemResult>
{
    public async Task<UpdateCatalogItemResult> Handle(UpdateCatalogItemCommand command,
        CancellationToken cancellationToken)
    {
        var existingItem = await catalogItemRepository.GetCatalogItemAsync(
            command.UpdateCatalogItemDto.Id,
            cancellationToken: cancellationToken);
        if (existingItem is null)
        {
            return new UpdateCatalogItemResult(false);
        }

        var catalogItem = command.UpdateCatalogItemDto.Adapt<CatalogItem>();
        var isSuccess = await catalogItemRepository.UpdateCatalogItemAsinc(
                catalogItem,
                cancellationToken: cancellationToken);
        return new UpdateCatalogItemResult(isSuccess);
    }
}
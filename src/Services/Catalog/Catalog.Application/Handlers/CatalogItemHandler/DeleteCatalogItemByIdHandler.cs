using Catalog.Application.Commands.CatalogItemCommands;

namespace Catalog.Application.Handlers.CatalogItemHandler;

public class DeleteCatalogItemByIdHandler(
    ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<DeleteCatalogItemByIdCommand, DeleteCatalogItemByIdResult>
{
    public async Task<DeleteCatalogItemByIdResult> Handle(
        DeleteCatalogItemByIdCommand command,
        CancellationToken cancellationToken)
    {
        var existingItem = await catalogItemRepository.GetCatalogItemAsync(
            command.Id,
            cancellationToken: cancellationToken);
        if (existingItem is null)
        {
            return new DeleteCatalogItemByIdResult(false);
        }

        var isSuccess =
            await catalogItemRepository
                .DeleteCatalogItemAsync(
                    existingItem.Id,
                    cancellationToken: cancellationToken);
        return new DeleteCatalogItemByIdResult(isSuccess);
    }
}
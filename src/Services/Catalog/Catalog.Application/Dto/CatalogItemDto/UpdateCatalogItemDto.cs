namespace Catalog.Application.Dto.CatalogItemDto;

public record UpdateCatalogItemDto(
    Guid Id,
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    Brand? Brand,
    Category? Category,
    decimal Price
    );
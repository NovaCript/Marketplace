using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Application.Dto.CatalogItemDto;

namespace Catalog.API.Controllers;

public class CatalogItemController : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResult),
        (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResult>> GetCatalogItems(
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCatalogItemsQuery(),
            cancellationToken: cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetCatalogItemByIdResult),
        (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetCatalogItemById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCatalogItemByIdQuery(id),
            cancellationToken: cancellationToken);
        return Ok(result);
    }

    [HttpGet("title/{catalogItemTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemsByTitleResult),
        (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsByTitleResult>>
        GetByTitle(string catalogItemTitle, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(
            new GetCatalogItemsByTitleQuery(catalogItemTitle),
            cancellationToken: cancellationToken);
        return Ok(result);
    }

    [HttpGet("brand/{brandTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemsByBrandTitleResult),
        (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsByBrandTitleResult>>
        GetByBrandTitle(
        string brandTitle, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(
                new GetCatalogItemsByBrandTitleQuery(brandTitle),
                cancellationToken: cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateCatalogItemResult),
        (int)HttpStatusCode.Created)]
    public async Task<ActionResult<CreateCatalogItemResult>> CreateCatalogItem(
        [FromBody] CreateCatalogItemDto catalogItemDto,
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(
            new CreateCatalogItemCommand(catalogItemDto),
            cancellationToken: cancellationToken);
        return CreatedAtAction(
            nameof(GetCatalogItemById),
            new { id = result.Id },
            result
            );
    }

    [HttpPut]
    [ProducesResponseType(typeof(UpdateCatalogItemResult), 
        (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateCatalogItemResult>> UpdateCatalogItem(
        [FromBody] UpdateCatalogItemCommand command,
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(
            command,
            cancellationToken: cancellationToken);
        return Ok(result);
    }
}
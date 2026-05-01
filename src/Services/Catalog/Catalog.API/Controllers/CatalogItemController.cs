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
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetCatalogItem(
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
}
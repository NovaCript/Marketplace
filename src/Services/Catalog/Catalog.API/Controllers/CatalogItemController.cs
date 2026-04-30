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
}
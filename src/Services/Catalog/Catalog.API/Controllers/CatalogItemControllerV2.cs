using Swashbuckle.AspNetCore.Annotations;

namespace Catalog.API.Controllers;

[ApiVersion("2")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/CatalogItem")]
public class CatalogItemControllerV2 : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResultV2), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new []{ "CatalogItemControllerV2" })]
    public async Task<ActionResult<GetCatalogItemsResultV2>> GetCatalogItems(
        CancellationToken cancellationToken,
        [FromQuery] int pageIndex = 1,
        [FromQuery] int pageSize = 5)
    {
        var query =
            new GetCatalogItemsQueryV2(
                PageIndex: pageIndex,
                PageSize: pageSize);
        var result = await Mediator.Send(
            query,
            cancellationToken: cancellationToken);
        return Ok(result);
    }
}
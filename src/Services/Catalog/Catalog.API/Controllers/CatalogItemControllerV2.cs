using Catalog.Domain.Specification;
using Swashbuckle.AspNetCore.Annotations;

namespace Catalog.API.Controllers;

[ApiVersion("2")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/CatalogItem")]
public class CatalogItemControllerV2 : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResultV2), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] { "CatalogItemControllerV2" })]
    public async Task<ActionResult<GetCatalogItemsResultV2>> GetCatalogItems(
        CancellationToken cancellationToken,
        [FromQuery] QueryArgs queryArgs)
    {
        var query =
            new GetCatalogItemsQueryV2(queryArgs);
        var result = await Mediator.Send(
            query,
            cancellationToken: cancellationToken);
        return Ok(result);
    }
}
namespace Catalog.API.Controllers;

public class CategoriesController : BaseController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCategoriesResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCategoriesResult>> GetCategories(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetCategoriesQuery(),
            cancellationToken: cancellationToken);
        return Ok(result);
    }
}
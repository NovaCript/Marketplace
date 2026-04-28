using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Responses.BrandResponses;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class BrandController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetBrandsResult>> GetBrands(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetBrandsQuery(), cancellationToken: cancellationToken);
        return Ok(result);
    }
}
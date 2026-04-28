using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Responses.BrandResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class BrandController(IMediator mediator) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<GetBrandsResult>> GetBrands(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetBrandsQuery(), cancellationToken: cancellationToken);
        return result;
    }
}
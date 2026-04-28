namespace Catalog.Application.Handlers.BrandHandler;

public class GetBrandsQueryHandler(
    IBrandRepository brandRepository
    ) : IRequestHandler<GetBrandsQuery, GetBrandsResult>
{
    public async Task<GetBrandsResult> Handle(GetBrandsQuery query,
        CancellationToken cancellationToken)
    {
        IEnumerable<Brand> brandList =
            await brandRepository
                .GetAllBrandsAsync(cancellationToken: cancellationToken);
        GetBrandsResult result = new GetBrandsResult(brandList);
        return result;
    }
}
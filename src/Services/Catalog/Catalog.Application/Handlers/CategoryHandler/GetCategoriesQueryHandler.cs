namespace Catalog.Application.Handlers.CategoryHandler;

public class GetCategoriesQueryHandler(
    ICategoryRepository categoryRepository
    ) : IRequestHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query,
        CancellationToken cancellationToken)
    {
        IEnumerable<Category> categoryList =
            await categoryRepository
                .GetAllCategoriesAsync(cancellationToken: cancellationToken);
        GetCategoriesResult result = new GetCategoriesResult(categoryList);
        return result;
    }
}

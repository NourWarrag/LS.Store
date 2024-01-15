using LS.Store.Application.Products.Queries.GetProductsWithPagination;

namespace LS.Store.Application.TodoItems.Queries.GetTodoItemsWithPagination;

public class GetProductsWithPaginationQueryValidator : AbstractValidator<GetProductsWithPaginationQuery>
{
    public GetProductsWithPaginationQueryValidator()
    {
        RuleFor(x => x.CategoryId)
            .Must(categoryId => categoryId == null || categoryId > 0)
            .WithMessage("CategoryId must be null or greater than 0.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageNumber must be greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("PageSize must be greater than or equal to 1.");
    }
}

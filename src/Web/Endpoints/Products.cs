
using LS.Store.Application.Common.Models;
using LS.Store.Application.Products.Queries;
using LS.Store.Application.Products.Queries.GetProductsWithPagination;

namespace LS.Store.Web.Endpoints;

public class Products : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetProducts);
    }

    public async Task<PaginatedList<ProductDto>> GetProducts(ISender sender, [AsParameters] GetProductsWithPaginationQuery query)
    {
        return await sender.Send(query);
    }
}

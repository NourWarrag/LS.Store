using LS.Store.Application.Products.Commands.CreateProduct;
using LS.Store.Application.Products.Queries.GetProductsWithPagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LS.Store.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    ProductsController(ISender sender)
    {
        _sender = sender;
    }


    [HttpGet]
    public async Task<IActionResult> GetProducts([AsParameters] GetProductsWithPaginationQuery query)
    {
        return Ok(await _sender.Send(query));

    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        await _sender.Send(command);
        return Created();
    }
}

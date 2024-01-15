using LS.Store.Application.Orders.Commands;
using LS.Store.Application.Orders.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LS.Store.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly ISender _sender;

    public OrdersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _sender.Send(new GetOrdersQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(long id)
    {
        return Ok(await _sender.Send(new GetOrderByIdQuery { Id = id }));
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
    {
        await _sender.Send(command);
        return Created();
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateOrder(long id, UpdateOrderCommand command)
    //{
    //    if (id != command.Id)
    //    {
    //        return BadRequest();
    //    }

    //    await _sender.Send(command);
    //    return NoContent();
    //}
}

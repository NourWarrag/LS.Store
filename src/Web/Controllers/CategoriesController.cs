using LS.Store.Application.Categories.Commands;
using LS.Store.Application.Categories.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LS.Store.Web.Controllers;
[Route("[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ISender _sender;

    public CategoriesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        return Ok(await _sender.Send(new GetCategoriesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(int id)
    {
        return Ok(await _sender.Send(new GetCategoryByIdQuery { Id = id }));
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
    {
        await _sender.Send(command);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, UpdateCategoryCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _sender.Send(command);
        return NoContent();
    }
}

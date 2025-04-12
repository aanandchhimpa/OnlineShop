using Application.Extensions.Product_Service.Category_service.Command.Create;
using Application.Features.Products_Service.Categories.Queries.GetbyIdQuery;
using Application.Features.Products_Service.Categories.Queries.GetAllQuery;
using Application.Features.Products_Service.Categories.Command.Delete;
using Application.Features.Products_Service.Categories.Command.Update;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace HostingApplication.Controllers
{
    [ApiController]
    [Route("api/admin/categories")]
    public class AdminCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            return category is not null ? Ok(category) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id) return BadRequest("Mismatched category ID.");
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }
    }
}

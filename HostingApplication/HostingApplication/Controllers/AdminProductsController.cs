using Application.Features.Products_Service.Products.Command.Create;
using Application.Features.Products_Service.Products.Command.Delete;
using Application.Features.Products_Service.Products.Command.Update;
using Application.Features.Products_Service.Products.Queries.GetAllQuery;
using Application.Features.Products_Service.Products.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HostingApplication.Controllers
{
    [ApiController]
    [Route("api/admin/products")]
    public class AdminProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetAllProductsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
                return BadRequest("Mismatched product ID.");
                
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
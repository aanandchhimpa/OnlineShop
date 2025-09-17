using Application.Features.Products_Service.Brands.Command.Create;
using Application.Features.Products_Service.Brands.Command.Delete;
using Application.Features.Products_Service.Brands.Command.Update;
using Application.Features.Products_Service.Brands.Queries.GetAllQuery;
using Application.Features.Products_Service.Brands.Queries.GetbyIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HostingApplication.Controllers
{
    [ApiController]
    [Route("api/admin/brands")]
    public class AdminBrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminBrandsController(IMediator mediator) { _mediator = mediator; }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var result = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(Guid id)
        {
            var result = await _mediator.Send(new GetBrandByIdQuery(id));
            return result.Succeeded ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(Guid id, [FromBody] UpdateBrandCommand command)
        {
            if (id != command.Id) return BadRequest("Mismatched brand ID.");
            var result = await _mediator.Send(command);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(Guid id)
        {
            var result = await _mediator.Send(new DeleteBrandCommand(id));
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
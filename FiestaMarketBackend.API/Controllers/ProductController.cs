using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Product.Commands;
using FiestaMarketBackend.Application.Product.Queries;
using FiestaMarketBackend.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiestaMarketBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Get

        [HttpPost]
        [Route("Filter")]
        public async Task<ActionResult<List<ProductResponse>>> GetByFilter([FromBody] GetProductsByFilterQuery query)
        {
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet]
        [Route("ByPage")]
        public async Task<ActionResult<List<ProductResponse>>> GetByPage(int pageIndex, int pageSize)
        {
            var query = new GetProductsByPageQuery(pageIndex, pageSize);
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<ProductResponse>> GetById(Guid id)
        {
            var query = new GetProductByIdQuery { Id = id};
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponse>>> Get()
        {
            var result = await _mediator.Send(new GetProductsQuery());

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        #endregion

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(Create), result.Value);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }
}

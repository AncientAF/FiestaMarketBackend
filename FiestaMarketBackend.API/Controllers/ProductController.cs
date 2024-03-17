using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Application.Products.Commands;
using FiestaMarketBackend.Application.Products.Queries;
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

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ProductResponse>> GetByFilter(GetProductsByFilterQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ProductResponse>> GetByPage(int pageIndex, int pageSize)
        {
            var query = new GetProductsByPageQuery(pageIndex, pageSize);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ProductResponse>> Get()
        {
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Put(UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);

            return Ok();
        }
    }
}

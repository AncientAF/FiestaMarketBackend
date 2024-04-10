using FiestaMarketBackend.API.Extensions;
using FiestaMarketBackend.Application.Product.Commands;
using FiestaMarketBackend.Application.Product.Queries;
using FiestaMarketBackend.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

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
        [ProducesResponseType<List<ProductResponse>>(200)]
        public async Task<IResult> GetByFilter([FromBody] GetProductsByFilterQuery query)
        {
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpGet]
        [Route("ByPage")]
        [ProducesResponseType<List<ProductResponse>>(200)]
        public async Task<IResult> GetByPage(int pageIndex, int pageSize)
        {
            var query = new GetProductsByPageQuery{ PageIndex = pageIndex, PageSize = pageSize };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType<ProductResponse>(200)]
        public async Task<IResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpGet]
        [ProducesResponseType<List<ProductResponse>>(200)]
        public async Task<IResult> Get()
        {
            var result = await _mediator.Send(new GetProductsQuery());

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        #endregion

        [HttpPut]
        [ProducesResponseType<ProductResponse>(200)]
        public async Task<IResult> Update([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType<Guid>(201)]
        public async Task<IResult> Create([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            var location = Url.Action("", nameof(NewsController));
            return Results.Created(location, result.Value);
        }

        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<IResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.StatusCode(204);
        }
    }
}

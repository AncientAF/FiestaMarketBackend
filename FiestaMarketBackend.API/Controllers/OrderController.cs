using FiestaMarketBackend.API.Extensions;
using FiestaMarketBackend.Application.Order.Commands;
using FiestaMarketBackend.Application.Order.Queries;
using FiestaMarketBackend.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

namespace FiestaMarketBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType<OrderResponse>(200)]
        public async Task<IResult> GetById(Guid id)
        {
            var query = new GetOrderByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpGet]
        [ProducesResponseType<List<OrderResponse>>(200)]
        public async Task<IResult> Get()
        {
            var result = await _mediator.Send(new GetOrdersQuery());

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpPut]
        [ProducesResponseType<OrderResponse>(200)]
        public async Task<IResult> Update([FromBody] UpdateOrderCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task<IResult> Delete(Guid id)
        {
            var command = new DeleteOrderCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.StatusCode(204);
        }

        [HttpPost]
        [ProducesResponseType<Guid>(201)]
        public async Task<IResult> Create([FromBody] CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            var location = Url.Action("", nameof(NewsController));
            return Results.Created(location, result.Value);
        }
    }
}

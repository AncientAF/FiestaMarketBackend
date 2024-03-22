using FiestaMarketBackend.Application.Order.Commands;
using FiestaMarketBackend.Application.Order.Queries;
using FiestaMarketBackend.Application.User.Commands;
using FiestaMarketBackend.Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetOrderByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Get(GetOrdersQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> Update(UpdateOrderCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> Delete(DeleteOrderCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> DeleteFromFavorite(CreateOrderCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}

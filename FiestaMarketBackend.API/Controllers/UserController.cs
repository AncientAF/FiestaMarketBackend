using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Application.User.Commands;
using FiestaMarketBackend.Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiestaMarketBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers(GetAllUsersQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<UserResponse>> GetById(GetByIdQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<CartResponse>> GetCart(GetCartQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<FavoriteResponse>> GetFavorites(GetFavoritesQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<OrderResponse>>> GetOrders(GetUserOrdersQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddToCart(AddToCartCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddToFavorite(AddToFavoriteCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> UpdateQtyInCart(UpdateQtyInCartCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> DeleteFromCart(DeleteFromCartCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch]
        [Route("[action]")]
        public async Task<IActionResult> DeleteFromFavorite(DeleteFromFavoriteCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }


        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand { Id = id};
            await _mediator.Send(command);

            return Ok();
        }


    }
}

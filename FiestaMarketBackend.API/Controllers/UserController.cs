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
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers(GetAllUsersQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<UserResponse>> GetById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Create), id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand { Id = id};
            await _mediator.Send(command);

            return Ok();
        }

        #region Favorite
        [HttpGet]
        [Route("favorite")]
        public async Task<ActionResult<FavoriteResponse>> GetFavorites(GetFavoritesQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> AddToFavorite(AddToFavoriteCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        [Route("favorite")]
        public async Task<IActionResult> DeleteFromFavorite(DeleteFromFavoriteCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        #endregion

        #region Cart
        [HttpGet]
        [Route("cart")]
        public async Task<ActionResult<CartResponse>> GetCart(GetCartQuery query)
        {
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("cart")]
        public async Task<IActionResult> AddToCart(AddToCartCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPatch]
        [Route("cart")]
        public async Task<IActionResult> UpdateQtyInCart(UpdateQtyInCartCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        [Route("cart")]
        public async Task<IActionResult> DeleteFromCart(DeleteFromCartCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        #endregion

        [HttpGet]
        [Route("orders{id:guid}")]
        public async Task<ActionResult<List<OrderResponse>>> GetOrders(Guid id)
        {
            var query = new GetUserOrdersQuery { Id = id };
            await _mediator.Send(query);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}

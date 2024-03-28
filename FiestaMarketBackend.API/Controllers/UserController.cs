using CSharpFunctionalExtensions;
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
        public async Task<ActionResult<List<UserResponse>>> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<UserResponse>> GetById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return CreatedAtAction(nameof(Create), result.Value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand { Id = id};
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        #region Favorite

        [HttpGet]
        [Route("favorite{id:guid}")]
        public async Task<ActionResult<FavoriteResponse>> GetFavorites(Guid id)
        {
            var query = new GetFavoritesQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> AddToFavorite(AddToFavoriteCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpDelete]
        [Route("favorite")]
        public async Task<IActionResult> DeleteFromFavorite(DeleteFromFavoriteCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        #endregion

        #region Cart

        [HttpGet]
        [Route("cart{id:guid}")]
        public async Task<ActionResult<CartResponse>> GetCart(Guid id)
        {
            var query = new GetCartQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpPost]
        [Route("cart")]
        public async Task<IActionResult> AddToCart(AddToCartCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpPatch]
        [Route("cart")]
        public async Task<IActionResult> UpdateQtyInCart(UpdateQtyInCartCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        [HttpDelete]
        [Route("cart")]
        public async Task<IActionResult> DeleteFromCart(DeleteFromCartCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }

        #endregion

        [HttpGet]
        [Route("orders{id:guid}")]
        public async Task<ActionResult<List<OrderResponse>>> GetOrders(Guid id)
        {
            var query = new GetUserOrdersQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

    }
}

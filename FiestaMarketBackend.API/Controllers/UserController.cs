using FiestaMarketBackend.API.Extensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Application.User.Commands;
using FiestaMarketBackend.Application.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IResult = Microsoft.AspNetCore.Http.IResult;

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
        [ProducesResponseType<List<UserResponse>>(200)]
        public async Task<IResult> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType<UserResponse>(200)]
        public async Task<IResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType<Guid>(201)]
        public async Task<IResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            var location = Url.Action("", nameof(NewsController));
            return Results.Created(location, result.Value);
        }

        [HttpPut]
        [ProducesResponseType<UserResponse>(200)]
        public async Task<IResult> Update(UpdateUserCommand command)
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
            var command = new DeleteUserCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.StatusCode(204);
        }

        #region Favorite

        [HttpGet]
        [Route("favorite{id:guid}")]
        [ProducesResponseType<List<FavoriteResponse>>(200)]
        public async Task<IResult> GetFavorites(Guid id)
        {
            var query = new GetFavoritesQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpPost]
        [Route("favorite")]
        [ProducesResponseType<FavoriteResponse>(200)]
        public async Task<IResult> AddToFavorite(AddToFavoriteCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpDelete]
        [Route("favorite")]
        [ProducesResponseType(204)]
        public async Task<IResult> DeleteFromFavorite(DeleteFromFavoriteCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.StatusCode(204);
        }

        #endregion

        #region Cart

        [HttpGet]
        [Route("cart{id:guid}")]
        [ProducesResponseType<CartResponse>(200)]
        public async Task<IResult> GetCart(Guid id)
        {
            var query = new GetCartQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpPost]
        [Route("cart")]
        [ProducesResponseType<CartResponse>(200)]
        public async Task<IResult> AddToCart(AddToCartCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpPatch]
        [Route("cart")]
        [ProducesResponseType<CartResponse>(200)]
        public async Task<IResult> UpdateQtyInCart(UpdateQtyInCartCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpDelete]
        [Route("cart")]
        [ProducesResponseType(204)]
        public async Task<IResult> DeleteFromCart(DeleteFromCartCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.StatusCode(204);
        }

        #endregion

        [HttpGet]
        [Route("orders{id:guid}")]
        [ProducesResponseType<List<OrderResponse>>(200)]
        public async Task<IResult> GetOrders(Guid id)
        {
            var query = new GetUserOrdersQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

    }
}

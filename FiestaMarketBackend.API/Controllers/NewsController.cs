using FiestaMarketBackend.API.Extensions;
using FiestaMarketBackend.Application.News.Commands.CreateNews;
using FiestaMarketBackend.Application.News.Commands.DeleteNews;
using FiestaMarketBackend.Application.News.Commands.UpdateNews;
using FiestaMarketBackend.Application.News.Queries;
using FiestaMarketBackend.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiestaMarketBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType<List<NewsResponse>>(200)]
        public async Task<IResult> GetByPage(int pageIndex, int pageSize)
        {
            var query = new GetNewsByPageQuery{ PageIndex = pageIndex, PageSize = pageSize};
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType<NewsResponse>(200)]
        public async Task<IResult> GetById(Guid id)
        {
            var query = new GetNewsByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpPut]
        [ProducesResponseType<NewsResponse>(200)]
        public async Task<IResult> Update(UpdateNewsCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result.Value);
        }

        [HttpPost]
        [ProducesResponseType<Guid>(201)]
        public async Task<IResult> Create(CreateNewsCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            var location = Url.Action("", nameof(NewsController));
            return Results.Created(location, result.Value);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(204)]
        public async Task<IResult> Delete(Guid id)
        {
            var command = new DeleteNewsCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.StatusCode(204);
        }
    }
}

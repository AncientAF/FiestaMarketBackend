using FiestaMarketBackend.Application.News.Commands.CreateNews;
using FiestaMarketBackend.Application.News.Commands.DeleteNews;
using FiestaMarketBackend.Application.News.Commands.UpdateNews;
using FiestaMarketBackend.Application.News.Queries.GetNewsByPage;
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
        public async Task<ActionResult<NewsResponse>> GetByPage(int pageIndex, int pageSize)
        {
            var query = new GetNewsByPageQuery(pageIndex, pageSize);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateNewsCommand command)
        {
            var news = await _mediator.Send(command);

            return Ok(news);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Create), id);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNewsCommand { Id = id };
            await _mediator.Send(command);

            return Ok();
        }
    }
}

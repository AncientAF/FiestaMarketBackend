﻿using FiestaMarketBackend.Application.News.Commands.CreateNews;
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
        public async Task<ActionResult<NewsResponse>> Get(int pageIndex, int pageSize)
        {
            var query = new GetNewsByPageQuery(pageIndex, pageSize);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateNewsCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsCommand command)
        {
            await _mediator.Send(command);

            return Ok();
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

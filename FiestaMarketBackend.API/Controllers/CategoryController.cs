﻿using FiestaMarketBackend.Application.Category;
using FiestaMarketBackend.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FiestaMarketBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<CategoryResponse>>> Get()
        {
            var query = new GetCategoryWithSubCategoriesQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Put(UpdateCategoryCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post(string name, Guid? parentId)
        {
            var command = new CreateCategoryCommand { Name = name, ParentCategoryID = parentId };
            await _mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);

            return Ok();
        }
    }
}
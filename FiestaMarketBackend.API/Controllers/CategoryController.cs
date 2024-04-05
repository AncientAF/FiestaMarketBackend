using FiestaMarketBackend.API.Extensions;
using FiestaMarketBackend.Application.Category;
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
        [ProducesResponseType<List<CategoryResponse>>(200)]
        public async Task<IResult> Get()
        {
            var query = new GetCategoryWithSubCategoriesQuery();
            var result = await _mediator.Send(query);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result);
        }

        [HttpPut]
        [ProducesResponseType<CategoryResponse>(200)]
        public async Task<IResult> Update(UpdateCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result);
        }

        [HttpPost]
        [ProducesResponseType<Guid>(201)]
        public async Task<IResult> Create(string name, Guid? parentId)
        {
            var command = new CreateCategoryCommand { Name = name, ParentCategoryID = parentId };
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
            var command = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsFailure)
                return result.ToProblemDetails();

            return Results.Ok(result);
        }
    }
}

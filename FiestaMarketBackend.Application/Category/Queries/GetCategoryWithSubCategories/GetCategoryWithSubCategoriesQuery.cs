using FiestaMarketBackend.Application.Responses;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class GetCategoryWithSubCategoriesQuery : IRequest<List<CategoryResponse>>
    {
    }
}

using CSharpFunctionalExtensions;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class DeleteCategoryCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
    }
}

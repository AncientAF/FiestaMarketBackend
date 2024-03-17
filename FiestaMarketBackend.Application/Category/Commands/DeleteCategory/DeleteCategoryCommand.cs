using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}

using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }
    }
}

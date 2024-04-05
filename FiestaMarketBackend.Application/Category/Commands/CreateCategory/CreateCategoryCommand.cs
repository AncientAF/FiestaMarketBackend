using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommand : IRequest<Result<Guid, Error>>
    {
        public string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }
    }
}

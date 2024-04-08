using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommand : ICommand<Result<Guid, Error>>
    {
        public required string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }
    }
}

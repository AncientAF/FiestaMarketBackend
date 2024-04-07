using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    public class CreateCategoryCommand : ICommand<Result<Guid, Error>>
    {
        public string Name { get; set; }
        public Guid? ParentCategoryID { get; set; }
    }
}

using MediatR;

namespace FiestaMarketBackend.Application.Category
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateCategoryCommand : IRequest<Result<CategoryResponse>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Category? ParentCategory { get; set; }
    }
}

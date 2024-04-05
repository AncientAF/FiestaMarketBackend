using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest<UnitResult<Error>>
    {

        public Guid Id { get; set; }
    }
}

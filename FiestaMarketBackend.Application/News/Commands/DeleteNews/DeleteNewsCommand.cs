using CSharpFunctionalExtensions;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest<Result>
    {

        public Guid Id { get; set; }
    }
}

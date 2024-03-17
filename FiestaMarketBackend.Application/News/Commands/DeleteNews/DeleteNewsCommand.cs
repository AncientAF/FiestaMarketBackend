using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest
    {

        public Guid Id { get; set; }
    }
}

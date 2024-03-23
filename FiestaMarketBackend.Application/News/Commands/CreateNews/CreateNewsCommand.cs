using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.CreateNews
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionMarkDown { get; set; }
    }
}

using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.CreateNews
{
    using FiestaMarketBackend.Core.Entities;
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand>
    {
        private readonly NewsRepository _newsRepository;

        public CreateNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.AddAsync(request.Adapt<News>());

            return;
        }
    }
}

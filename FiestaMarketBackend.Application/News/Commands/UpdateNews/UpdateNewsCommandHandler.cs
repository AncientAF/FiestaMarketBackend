using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.UpdateNews
{
    using FiestaMarketBackend.Core.Entities;
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand>
    {
        private readonly NewsRepository _newsRepository;

        public UpdateNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.UpdateAsync(request.Adapt<News>());

            return;
        }
    }
}

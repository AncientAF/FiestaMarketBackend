using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.UpdateNews
{
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, NewsResponse>
    {
        private readonly NewsRepository _newsRepository;

        public UpdateNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<NewsResponse> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.UpdateAsync(request.Adapt<News>());

            return news.Adapt<NewsResponse>();
        }
    }
}

using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, NewsResponse>
    {
        private readonly NewsRepository _newsRepository;

        public GetNewsByIdQueryHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<NewsResponse> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var news = await _newsRepository.GetByIdAsync(request.Id);

            return news.Adapt<NewsResponse>();
        }
    }
}

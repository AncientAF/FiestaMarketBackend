using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Queries.GetNewsByPage
{
    public class GetNewsByPageQueryHandler : IRequestHandler<GetNewsByPageQuery, List<NewsResponse>>
    {
        private readonly NewsRepository _newsRepository;

        public GetNewsByPageQueryHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<List<NewsResponse>> Handle(GetNewsByPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.GetByPageAsync(request.PageIndex, request.PageSize);

            return result.Adapt<List<NewsResponse>>();
        }
    }
}

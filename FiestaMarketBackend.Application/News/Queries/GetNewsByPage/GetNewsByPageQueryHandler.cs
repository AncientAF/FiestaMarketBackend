using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

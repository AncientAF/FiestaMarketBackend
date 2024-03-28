using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByPageQueryHandler : IRequestHandler<GetNewsByPageQuery, Result<List<NewsResponse>>>
    {
        private readonly NewsRepository _newsRepository;

        public GetNewsByPageQueryHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Result<List<NewsResponse>>> Handle(GetNewsByPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.GetByPageAsync(request.PageIndex, request.PageSize);

            if (result.IsFailure)
                return Result.Failure<List<NewsResponse>>(result.Error);

            return Result.Success(result.Value.Adapt<List<NewsResponse>>());
        }
    }
}

using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News
{
    public class GetNewsByPageQueryHandler : IRequestHandler<GetNewsByPageQuery, Result<List<NewsResponse>, Error>>
    {
        private readonly INewsRepository _newsRepository;

        public GetNewsByPageQueryHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Result<List<NewsResponse>, Error>> Handle(GetNewsByPageQuery request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.GetByPageAsync(request.PageIndex, request.PageSize);

            if (result.IsFailure)
                return Result.Failure<List<NewsResponse>, Error>(result.Error);

            return Result.Success<List<NewsResponse>, Error>(result.Value.Adapt<List<NewsResponse>>());
        }
    }
}

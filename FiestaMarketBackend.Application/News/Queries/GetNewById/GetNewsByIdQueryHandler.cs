using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Queries
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, Result<NewsResponse>>
    {
        private readonly NewsRepository _newsRepository;

        public GetNewsByIdQueryHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Result<NewsResponse>> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.GetByIdAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<NewsResponse>(result.Error);

            return Result.Success(result.Value.Adapt<NewsResponse>());
        }
    }
}

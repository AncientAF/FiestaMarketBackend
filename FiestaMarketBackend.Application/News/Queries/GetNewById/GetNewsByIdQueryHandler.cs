using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, Result<NewsResponse, Error>>
    {
        private readonly INewsRepository _newsRepository;

        public GetNewsByIdQueryHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Result<NewsResponse, Error>> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.GetByIdAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure<NewsResponse, Error>(result.Error);

            return Result.Success<NewsResponse, Error>(result.Value.Adapt<NewsResponse>());
        }
    }
}

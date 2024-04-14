using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    using FiestaMarketBackend.Core.Repositories;

    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Result<NewsResponse, Error>>
    {
        private readonly INewsRepository _newsRepository;

        public UpdateNewsCommandHandler(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Result<NewsResponse, Error>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.UpdateAsync(request.Adapt<News>());

            if (result.IsFailure)
                return Result.Failure<NewsResponse, Error>(result.Error);

            return Result.Success<NewsResponse, Error>(result.Value.Adapt<NewsResponse>());
        }
    }
}

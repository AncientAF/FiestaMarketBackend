using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.UpdateNews
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Result<NewsResponse, Error>>
    {
        private readonly NewsRepository _newsRepository;

        public UpdateNewsCommandHandler(NewsRepository newsRepository)
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

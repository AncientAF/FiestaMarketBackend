using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.UpdateNews
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Result<NewsResponse>>
    {
        private readonly NewsRepository _newsRepository;

        public UpdateNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Result<NewsResponse>> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.UpdateAsync(request.Adapt<News>());

            if (result.IsFailure)
                return Result.Failure<NewsResponse>(result.Error);

            return Result.Success(result.Value.Adapt<NewsResponse>());
        }
    }
}

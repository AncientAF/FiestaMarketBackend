using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.CreateNews
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Result<Guid, Error>>
    {
        private readonly NewsRepository _newsRepository;

        public CreateNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Result<Guid, Error>> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.AddAsync(request.Adapt<News>());

            if (result.IsFailure)
                return Result.Failure<Guid, Error>(result.Error);

            return Result.Success<Guid, Error>(result.Value);
        }
    }
}

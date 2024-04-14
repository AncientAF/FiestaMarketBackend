using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.News
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    using FiestaMarketBackend.Core.Repositories;

    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Result<Guid, Error>>
    {
        private readonly INewsRepository _newsRepository;

        public CreateNewsCommandHandler(INewsRepository newsRepository)
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

using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    internal class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, UnitResult<Error>>
    {
        private readonly NewsRepository _newsRepository;

        public DeleteNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<UnitResult<Error>> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.DeleteAsync(request.Id);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            return UnitResult.Success<Error>();
        }
    }
}

using CSharpFunctionalExtensions;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    internal class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, Result>
    {
        private readonly NewsRepository _newsRepository;

        public DeleteNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<Result> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var result = await _newsRepository.DeleteAsync(request.Id);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            return Result.Success();
        }
    }
}

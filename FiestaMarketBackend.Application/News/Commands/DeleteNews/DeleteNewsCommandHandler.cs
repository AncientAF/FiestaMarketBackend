using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.News
{
    internal class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, UnitResult<Error>>
    {
        private readonly INewsRepository _newsRepository;

        public DeleteNewsCommandHandler(INewsRepository newsRepository)
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

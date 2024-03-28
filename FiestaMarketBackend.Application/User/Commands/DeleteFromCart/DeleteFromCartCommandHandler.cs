using CSharpFunctionalExtensions;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromCartCommandHandler : IRequestHandler<DeleteFromCartCommand, Result>
    {
        private readonly UserRepository _userRepository;

        public DeleteFromCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(DeleteFromCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.DeleteProductsFromCartAsync(request.Id, request.ItemsId);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            return Result.Success();
        }
    }
}

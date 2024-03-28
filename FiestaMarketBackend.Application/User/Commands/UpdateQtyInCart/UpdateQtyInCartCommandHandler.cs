using CSharpFunctionalExtensions;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class UpdateQtyInCartCommandHandler : IRequestHandler<UpdateQtyInCartCommand, Result>
    {
        private readonly UserRepository _userRepository;

        public UpdateQtyInCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> Handle(UpdateQtyInCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.UpdateQtyInCartAsync(request.UserId, request.Items);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            return Result.Success();
        }
    }
}

using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class UpdateQtyInCartCommandHandler : IRequestHandler<UpdateQtyInCartCommand, Result<CartResponse, Error>>
    {
        private readonly UserRepository _userRepository;

        public UpdateQtyInCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CartResponse, Error>> Handle(UpdateQtyInCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.UpdateQtyInCartAsync(request.UserId, request.Items);

            if (result.IsFailure)
                return Result.Failure<CartResponse, Error>(result.Error);

            return Result.Success<CartResponse, Error>(result.Value.Adapt<CartResponse>());
        }
    }
}

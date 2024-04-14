using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    public class UpdateQtyInCartCommandHandler : IRequestHandler<UpdateQtyInCartCommand, Result<CartResponse, Error>>
    {
        private readonly IUserRepository _userRepository;

        public UpdateQtyInCartCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CartResponse, Error>> Handle(UpdateQtyInCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.UpdateQtyInCartAsync(request.Id, request.Items);

            if (result.IsFailure)
                return Result.Failure<CartResponse, Error>(result.Error);

            return Result.Success<CartResponse, Error>(result.Value.Adapt<CartResponse>());
        }
    }
}

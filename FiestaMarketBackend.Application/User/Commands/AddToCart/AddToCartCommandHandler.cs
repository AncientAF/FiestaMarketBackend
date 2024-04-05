using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    internal class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Result<CartResponse, Error>>
    {
        private readonly UserRepository _userRepository;

        public AddToCartCommandHandler(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CartResponse, Error>> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.AddProductsToCartAsync(request.UserId, request.Items.Adapt<List<CartItem>>());

            if (result.IsFailure)
                return Result.Failure<CartResponse, Error>(result.Error);

            return Result.Success<CartResponse, Error>(result.Value.Adapt<CartResponse>());
        }
    }
}

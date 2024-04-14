using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Repositories;
using Mapster;
using MediatR;

namespace FiestaMarketBackend.Application.User
{
    internal class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Result<CartResponse, Error>>
    {
        private readonly IUserRepository _userRepository;

        public AddToCartCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CartResponse, Error>> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.AddProductsToCartAsync(request.Id, request.Items.Adapt<List<CartItem>>());

            if (result.IsFailure)
                return Result.Failure<CartResponse, Error>(result.Error);

            return Result.Success<CartResponse, Error>(result.Value.Adapt<CartResponse>());
        }
    }
}

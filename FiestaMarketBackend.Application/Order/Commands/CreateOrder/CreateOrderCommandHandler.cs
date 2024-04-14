using MediatR;

namespace FiestaMarketBackend.Application.Order
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    using FiestaMarketBackend.Core.Repositories;
    using Mapster;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid, Error>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<Result<Guid, Error>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.Adapt<Order>();

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user.IsFailure)
                return Result.Failure<Guid, Error>(user.Error);

            order.User = user.Value;

            var result = await _orderRepository.AddAsync(order);

            if (result.IsFailure)
                return Result.Failure<Guid, Error>(result.Error);

            return Result.Success<Guid, Error>(result.Value);
        }
    }
}

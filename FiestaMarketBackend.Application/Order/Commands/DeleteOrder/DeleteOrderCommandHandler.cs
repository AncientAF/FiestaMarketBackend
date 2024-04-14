using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Repositories;
using MediatR;

namespace FiestaMarketBackend.Application.Order
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, UnitResult<Error>>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<UnitResult<Error>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.DeleteAsync(request.Id);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            return UnitResult.Success<Error>();
        }
    }
}

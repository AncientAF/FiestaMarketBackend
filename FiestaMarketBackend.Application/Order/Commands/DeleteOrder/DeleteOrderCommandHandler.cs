﻿using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Order.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, UnitResult<Error>>
    {
        private readonly OrderRepository _orderRepository;

        public DeleteOrderCommandHandler(OrderRepository orderRepository)
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

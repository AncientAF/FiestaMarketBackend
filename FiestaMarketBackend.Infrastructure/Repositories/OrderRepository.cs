using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FiestaMarketBackend.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FiestaDbContext _dbContext;

        public OrderRepository(FiestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<Order>, Error>> GetAsync()
        {
            var result = await _dbContext.Orders
                .Include(o => o.Address)
                .Include(o => o.Items)
                .Include(o => o.User)
                .AsNoTracking()
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<Order>, Error>(Error.NotFound("Order.NotFound", "No orders to return"));

            return Result.Success<List<Order>, Error>(result);

        }

        public async Task<Result<Order, Error>> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Orders
                .Include(o => o.Address)
                .Include(o => o.Items)
                .Include(o => o.User)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

            if (result is null)
                return Result.Failure<Order, Error>(Error.NotFound("Order.NotFoundById", $"Can't find order with id {id}"));

            return Result.Success<Order, Error>(result);
        }

        public async Task<Result<Guid, Error>> AddAsync(Order order)
        {
            try
            {
                var id = Guid.NewGuid();
                order.Id = id;

                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();

                return Result.Success<Guid, Error>(id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid, Error>(Error.Failure("Order.AddingOrderFailure", "Error adding order"));
            }
        }

        public async Task<Result<Order, Error>> UpdateAsync(Order updatedOrder)
        {
            var result = await _dbContext.Orders.SingleOrDefaultAsync(p => p.Id == updatedOrder.Id);

            if (result is null)
                return Result.Failure<Order, Error>(Error.NotFound("Order.UpdatingOrderNotFound", $"Can't find order with id {updatedOrder.Id}"));

            try
            {
                _dbContext.Entry(result).CurrentValues.SetValues(updatedOrder);
                await _dbContext.SaveChangesAsync();

                return Result.Success<Order, Error>(result);
            }
            catch (Exception)
            {
                return Result.Failure<Order, Error>(Error.Failure("Order.UpdateError", "Error updating order"));
            }
        }

        public async Task<UnitResult<Error>> DeleteAsync(Guid id)
        {
            await _dbContext.Orders
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();

            return UnitResult.Success<Error>();
        }
    }
}

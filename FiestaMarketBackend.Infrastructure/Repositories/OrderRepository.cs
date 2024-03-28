using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiestaMarketBackend.Infrastructure.Repositories
{
    public class OrderRepository
    {
        private readonly FiestaDbContext _dbContext;

        public OrderRepository(FiestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<List<Order>>> GetAsync()
        {
            var result = await _dbContext.Orders
                .Include(o => o.Address)
                .Include(o => o.Items)
                .Include(o => o.User)
                .AsNoTracking()
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<Order>>("No orders to return");

            return Result.Success(result);

        }

        public async Task<Result<Order>> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Orders
                .Include(o => o.Address)
                .Include(o => o.Items)
                .Include(o => o.User)
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

            if (result is null)
                return Result.Failure<Order>($"Can't find order with id {id}");

            return Result.Success(result);
        }

        public async Task<Result<Guid>> AddAsync(Order order)
        {
            try
            {
                var id = Guid.NewGuid();
                order.Id = id;

                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();

                return Result.Success(id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid>("Error adding order");
            }
        }

        public async Task<Result<Order>> UpdateAsync(Order updatedOrder)
        {
            var result = await _dbContext.Orders.SingleOrDefaultAsync(p => p.Id == updatedOrder.Id);

            if (result is null)
                return Result.Failure<Order>($"Can't find order with id {updatedOrder.Id}");

            try
            {
                _dbContext.Entry(result).CurrentValues.SetValues(updatedOrder);
                await _dbContext.SaveChangesAsync();

                return Result.Success(result);
            }
            catch (Exception)
            {
                return Result.Failure<Order>("Error updating order");
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            await _dbContext.Orders
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();

            return Result.Success();
        }
    }
}

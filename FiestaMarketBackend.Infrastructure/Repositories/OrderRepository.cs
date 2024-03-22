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

        public async Task<List<Order>> GetAsync()
        {
            return await _dbContext.Orders
                .Include(o => o.Address)
                .Include(o => o.Items)
                .Include(o => o.User)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Orders
                .Include(o => o.Address)
                .Include(o => o.Items)
                .Include(o => o.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order updatedOrder)
        {
            await _dbContext.Orders
                .Where(p => p.Id == updatedOrder.Id)
                .ExecuteUpdateAsync(update => update
                    .SetProperty(o => o.Address, updatedOrder.Address)
                    .SetProperty(o => o.Items, updatedOrder.Items)
                    .SetProperty(o => o.Status, updatedOrder.Status)
                    .SetProperty(o => o.TotalPrice, updatedOrder.TotalPrice)
                    .SetProperty(o => o.User, updatedOrder.User));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Orders
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

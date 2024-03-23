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

        public async Task<Guid> AddAsync(Order order)
        {
            var id = Guid.NewGuid();
            order.Id = id;

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return id;
        }

        public async Task<Order> UpdateAsync(Order updatedOrder)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(p => p.Id == updatedOrder.Id);

            _dbContext.Entry(order).CurrentValues.SetValues(updatedOrder);
            await _dbContext.SaveChangesAsync();

            return order;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Orders
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;

namespace FiestaMarketBackend.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<Result<Guid, Error>> AddAsync(Order order);
        Task<UnitResult<Error>> DeleteAsync(Guid id);
        Task<Result<List<Order>, Error>> GetAsync();
        Task<Result<Order, Error>> GetByIdAsync(Guid id);
        Task<Result<Order, Error>> UpdateAsync(Order updatedOrder);
    }
}
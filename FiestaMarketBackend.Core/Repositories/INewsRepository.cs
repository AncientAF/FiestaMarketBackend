using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;

namespace FiestaMarketBackend.Core.Repositories
{
    public interface INewsRepository
    {
        Task<Result<Guid, Error>> AddAsync(News news);
        Task<UnitResult<Error>> DeleteAsync(Guid id);
        Task<Result<List<News>, Error>> GetAsync();
        Task<Result<News, Error>> GetByIdAsync(Guid id);
        Task<Result<List<News>, Error>> GetByPageAsync(int page, int pageSize);
        Task<Result<News, Error>> UpdateAsync(News updatedNews);
    }
}
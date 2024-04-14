using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;

namespace FiestaMarketBackend.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Result<Guid, Error>> AddAsync(string name, Guid? parentCategoryId);
        Task<UnitResult<Error>> DeleteAsync(Guid id);
        Task<Result<List<Category>, Error>> GetAsync();
        Task<Result<Category, Error>> GetByIdAsync(Guid? id);
        Task<Result<List<Category>, Error>> GetWithSubCategoriesAsync();
        Task<Result<Category, Error>> UpdateAsync(Category updatedCategory);
    }
}
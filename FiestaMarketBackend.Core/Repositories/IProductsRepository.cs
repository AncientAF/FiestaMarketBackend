using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;

namespace FiestaMarketBackend.Core.Repositories
{
    public interface IProductsRepository
    {
        Task<Result<Guid, Error>> AddAsync(Product product);
        Task<UnitResult<Error>> AddImagesAsync(Guid id, List<Image> images);
        Task<UnitResult<Error>> DeleteAsync(Guid id);
        Task<UnitResult<Error>> DeleteImagesAsync(Guid id, List<Guid> images);
        Task<Result<List<Product>, Error>> GetAsync();
        Task<Result<List<Product>, Error>> GetByFilterAsync(string? name, Guid? categoryId);
        Task<Result<Product, Error>> GetByIdAsync(Guid id);
        Task<Result<List<Product>, Error>> GetByPageAsync(int pageIndex, int pageSize);
        Task<Result<List<Image>, Error>> GetImagesAsync(Guid id);
        Task<Result<List<Product>, Error>> GetWithImagesAsync();
        Task<Result<Product, Error>> UpdateAsync(Product updatedProduct);
    }
}
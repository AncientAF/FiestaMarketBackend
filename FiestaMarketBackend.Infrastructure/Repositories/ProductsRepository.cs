using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FiestaMarketBackend.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly FiestaDbContext _dbContext;

        public ProductsRepository(FiestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Get методы
        public async Task<Result<List<Product>, Error>> GetAsync()
        {
            var result = await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .Include(p => p.Category)
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<Product>, Error>(Error.NotFound("Products.NotFound", "No products to return"));

            return Result.Success<List<Product>, Error>(result);
        }

        public async Task<Result<List<Product>, Error>> GetWithImagesAsync()
        {
            var result = await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .Include(p => p.Images)
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<Product>, Error>(Error.NotFound("Products.NotFound", "No products to return"));

            return Result.Success<List<Product>, Error>(result);
        }

        public async Task<Result<Product, Error>> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (result is null)
                return Result.Failure<Product, Error>(Error.NotFound("Product.NotFoundById", $"No products with id {id}"));

            return Result.Success<Product, Error>(result);
        }

        public async Task<Result<List<Product>, Error>> GetByFilterAsync(string? name, Guid? categoryId)
        {
            var query = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Description)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (categoryId != null)
                query = query.Where(p => p.Category != null && p.Category.Id == categoryId);

            var result = await query.ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<Product>, Error>(Error.NotFound("Products.NotFoundByFilter", "No products to return"));

            return Result.Success<List<Product>, Error>(result);
        }

        public async Task<Result<List<Product>, Error>> GetByPageAsync(int pageIndex, int pageSize)
        {
            var result = await _dbContext.Products
                .Include(p => p.Images)
                .Include(p => p.Description)
                .Include(p => p.Category)
                .AsNoTracking()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<Product>, Error>(Error.NotFound("Products.NotFoundByPage", "No products to return"));

            return Result.Success<List<Product>, Error>(result);
        }
        #endregion

        public async Task<Result<Guid, Error>> AddAsync(Product product)
        {
            try
            {
                var id = Guid.NewGuid();
                product.Id = id;

                await _dbContext.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                return Result.Success<Guid, Error>(id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid, Error>(Error.Failure("Products.FailureAdding", "Error adding product"));
            }
        }

        public async Task<Result<Product, Error>> UpdateAsync(Product updatedProduct)
        {
            var result = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == updatedProduct.Id);

            if (result is null)
                return Result.Failure<Product, Error>(Error.NotFound("Products.NotFoundForUpdating", $"No products to update with id {updatedProduct.Id}"));

            try
            {
                _dbContext.Entry(result).CurrentValues.SetValues(updatedProduct);
                await _dbContext.SaveChangesAsync();

                return Result.Success<Product, Error>(result);
            }
            catch (Exception)
            {
                return Result.Failure<Product, Error>(Error.Failure("Products.ErrorUpdating", "Error updating product"));
            }
        }

        public async Task<UnitResult<Error>> DeleteAsync(Guid id)
        {
            await _dbContext.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            return UnitResult.Success<Error>();
        }

        public async Task<Result<List<Image>, Error>> GetImagesAsync(Guid id)
        {
            var result = await _dbContext.Products
                .Include(p => p.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result is null)
                return Result.Failure<List<Image>, Error>(Error.NotFound("Products.NotFoundById", $"No products with id {id}"));

            if (result.Images is null || result.Images.Count == 0)
                return Result.Failure<List<Image>, Error>(Error.NotFound("Products.NotFoundImages", $"No images associated with product with id {id}"));

            return Result.Success<List<Image>, Error>(result.Images);
        }

        public async Task<UnitResult<Error>> DeleteImagesAsync(Guid id, List<Guid> images)
        {
            var result = await _dbContext.Products.Include(p => p.Images).SingleOrDefaultAsync(p => p.Id == id);

            if (result is null)
                return UnitResult.Failure(Error.NotFound("Products.NotFoundById", $"No products with id {id}"));

            if (result.Images is null || result.Images.Count == 0)
                return UnitResult.Failure(Error.NotFound("Products.NotFoundImages", $"No images associated with product with id {id}"));

            result.Images.RemoveAll(i => images.Contains(i.Id));

            await _dbContext.SaveChangesAsync();

            return UnitResult.Success<Error>();
        }

        public async Task<UnitResult<Error>> AddImagesAsync(Guid id, List<Image> images)
        {
            var result = await _dbContext.Products.Include(p => p.Images).SingleOrDefaultAsync(p => p.Id == id);

            if (result is null)
                return UnitResult.Failure(Error.NotFound("Products.NotFoundById", $"No products with id {id}"));

            result.Images?.AddRange(images);
            await _dbContext.SaveChangesAsync();

            return UnitResult.Success<Error>();
        }
    }
}

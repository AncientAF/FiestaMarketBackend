using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiestaMarketBackend.Infrastructure.Repositories
{
    public class ProductsRepository
    {
        private readonly FiestaDbContext _dbContext;

        public ProductsRepository(FiestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Get методы
        public async Task<Result<List<Product>>> GetAsync()
        {
            var result = await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .Include(p => p.Category)
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<Product>>("No products to return");

            return Result.Success(result);
        }

        public async Task<Result<List<Product>>> GetWithImagesAsync()
        {
            var result = await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .Include(p => p.Images)
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<Product>>("No products to return");

            return Result.Success(result);
        }

        public async Task<Result<Product>> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .SingleOrDefaultAsync(p => p.Id == id);

            if (result is null)
                return Result.Failure<Product>($"No products with id {id}");

            return Result.Success(result);
        }

        public async Task<Result<List<Product>>> GetByFilterAsync(string? name, Guid? categoryId)
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
                return Result.Failure<List<Product>>("No products to return");

            return Result.Success(result);
        }

        public async Task<Result<List<Product>>> GetByPageAsync(int pageIndex, int pageSize)
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
                return Result.Failure<List<Product>>("No products to return");

            return Result.Success(result);
        }
        #endregion

        public async Task<Result<Guid>> AddAsync(Product product)
        {
            try
            {
                var id = Guid.NewGuid();
                product.Id = id;

                await _dbContext.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                return Result.Success(id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid>("Error adding product");
            }
        }

        public async Task<Result<Product>> UpdateAsync(Product updatedProduct)
        {
            var result = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == updatedProduct.Id);

            if(result is null)
                return Result.Failure<Product>($"No products to update with id {updatedProduct.Id}");

            try
            {
                _dbContext.Entry(result).CurrentValues.SetValues(updatedProduct);
                await _dbContext.SaveChangesAsync();

                return Result.Success(result);
            }
            catch (Exception)
            {
                return Result.Failure<Product>("Error updating product");
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            await _dbContext.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            return Result.Success();
        }

        public async Task<Result<List<Image>>> GetImagesAsync(Guid id)
        {
            var result = await _dbContext.Products
                .Include(p => p.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if(result is null)
                return Result.Failure<List<Image>>($"No products with id {id}");

            if(result.Images is null || result.Images.Count == 0)
                return Result.Failure<List<Image>>($"No images associated with product with id {id}");

            return Result.Success(result.Images);
        }

        public async Task<Result> DeleteImagesAsync(Guid id, List<Guid> images)
        {
            var result = await _dbContext.Products.Include(p => p.Images).SingleOrDefaultAsync(p => p.Id == id);

            if (result is null)
                return Result.Failure($"No products with id {id}");

            if (result.Images is null || result.Images.Count == 0)
                return Result.Failure($"No images associated with product with id {id}");

            result.Images.RemoveAll(i => images.Contains(i.Id));

            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result> AddImagesAsync(Guid id, List<Image> images)
        {
            var result = await _dbContext.Products.Include(p => p.Images).SingleOrDefaultAsync(p => p.Id == id);

            if (result is null)
                return Result.Failure($"No products with id {id}");

            result.Images?.AddRange(images);
            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }
    }
}

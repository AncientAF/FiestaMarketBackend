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
        public async Task<List<Product>> GetAsync()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<List<Product>> GetWithImagesAsync()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetByFilterAsync(string? name, Guid? categoryId)
        {
            var query = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Description)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.Contains(name));

            if (categoryId != null)
                query = query.Where(p => p.Category.Id == categoryId);

            var res = await query.ToListAsync();
            return res;
        }

        public async Task<List<Product>> GetByPageAsync(int pageIndex, int pageSize)
        {
            return await _dbContext.Products
                .Include(p => p.Images)
                .Include(p => p.Description)
                .Include(p => p.Category)
                .AsNoTracking()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        #endregion

        public async Task<Guid> AddAsync(Product product)
        {
            var id = Guid.NewGuid();
            product.Id = id;

            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return id;
        }

        public async Task<Product> UpdateAsync(Product updatedProduct)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);

            _dbContext.Entry(product).CurrentValues.SetValues(updatedProduct);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Image>> GetImagesAsync(Guid id)
        {
            return (await _dbContext.Products
                .Include(p => p.Images)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id)).Images;
        }

        public async Task DeleteImagesAsync(Guid productId, List<Guid> images)
        {
            var product = await _dbContext.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == productId);
            product.Images.RemoveAll(i => images.Contains(i.Id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddImagesAsync(Guid productId, List<Image> images)
        {
            var product = await _dbContext.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == productId);
            product.Images.AddRange(images);
            await _dbContext.SaveChangesAsync();
        }
    }
}

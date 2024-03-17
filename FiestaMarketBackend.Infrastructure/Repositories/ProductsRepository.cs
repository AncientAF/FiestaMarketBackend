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

        public async Task<List<Product>> GetByFilterAsync(string name, Category category)
        {
            var query = _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.Description);

            if (!string.IsNullOrEmpty(name))
                query.Where(p => p.Name.Contains(name));

            if (category != null)
                query.Where(p => p.Category == category);


            return await query.ToListAsync();
        }

        public async Task<List<Product>> GetByPageAsync(int pageIndex, int pageSize)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Images)
                //.Include(p => p.Description)
                .Include(p => p.Category)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        #endregion

        public async Task AddAsync(Product product)
        {
            //var productToAdd = new Product
            //{
            //    Id = product.Id,
            //    Name = product.Name,
            //    Description = product.Description
            //};

            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product updatedProduct)
        {
            await _dbContext.Products
                .Where(p => p.Id == updatedProduct.Id)
                .ExecuteUpdateAsync(update => update
                    .SetProperty(p => p.Name, updatedProduct.Name)
                    .SetProperty(p => p.Price, updatedProduct.Price)
                    .SetProperty(p => p.Recommended, updatedProduct.Recommended)
                    .SetProperty(p => p.Relevant, updatedProduct.Relevant)
                    .SetProperty(p => p.FullName, updatedProduct.FullName)
                    .SetProperty(p => p.Category, updatedProduct.Category)
                    .SetProperty(p => p.Description.Text, updatedProduct.Description.Text)
                    .SetProperty(p => p.Description.Games, updatedProduct.Description.Games)
                    .SetProperty(p => p.Description.Material, updatedProduct.Description.Material)
                    .SetProperty(p => p.Description.Size, updatedProduct.Description.Size));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

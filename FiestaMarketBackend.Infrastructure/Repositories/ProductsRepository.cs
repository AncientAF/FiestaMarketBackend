using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<List<Product>> Get()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .ToListAsync();
        }

        public async Task<List<Product>> GetWithImages()
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .Include(p => p.Images)
                .ToListAsync();
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Include(p => p.Description)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetByFilter(string name, Category category)
        {
            var query = _dbContext.Products.AsNoTracking();

            if (!string.IsNullOrEmpty(name))
                query.Where(p => p.Name.Contains(name));

            if (category != null)
                query.Where(p => p.Category == category);


            return await query.ToListAsync();
        }

        public async Task<List<Product>> GetByPage(int page, int pageSize)
        {
            return await _dbContext.Products
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        #endregion

        public async Task Add(Guid id, string name, ProductDescription description)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                Description = description
            };

            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Product updatedProduct)
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

        public async Task Delete(Guid id)
        {
            await _dbContext.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

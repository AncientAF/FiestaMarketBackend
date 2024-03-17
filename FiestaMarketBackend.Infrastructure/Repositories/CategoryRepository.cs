using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiestaMarketBackend.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly FiestaDbContext _dbContext;

        public CategoryRepository(FiestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAsync()
        {
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetWithSubCategoriesAsync()
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .Include(c => c.ParentCategory)
                .Include(c => c.SubCategories)
                .Where(c => c.ParentCategory == null)
                .ToListAsync();
        }

        public async Task AddAsync(string name, Guid? parentCategoryId)
        {
            var categoryToAdd = new Category
            {
                Name = name,
                ParentCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == parentCategoryId) ?? null,
            };

            await _dbContext.Categories.AddAsync(categoryToAdd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category updatedCategory)
        {
            await _dbContext.Categories
                .Where(p => p.Id == updatedCategory.Id)
                .ExecuteUpdateAsync(update => update
                    .SetProperty(p => p.Name, updatedCategory.Name)
                    .SetProperty(p => p.ParentCategory, updatedCategory.ParentCategory));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Categories
                .AsNoTracking()
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
        }



    }
}

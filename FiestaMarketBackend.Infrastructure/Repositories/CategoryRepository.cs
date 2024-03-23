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
            return await _dbContext.Categories
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetWithSubCategoriesAsync()
        {
            return await _dbContext.Categories
                .Where(c => c.ParentCategory == null)
                .Include(c => c.SubCategories)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Guid> AddAsync(string name, Guid? parentCategoryId)
        {
            var id = Guid.NewGuid();
            var categoryToAdd = new Category
            {
                Id = id,
                Name = name,
                ParentCategory = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == parentCategoryId) ?? null,
            };

            await _dbContext.Categories.AddAsync(categoryToAdd);
            await _dbContext.SaveChangesAsync();

            return id;
        }

        public async Task<Category> UpdateAsync(Category updatedCategory)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(p => p.Id == updatedCategory.Id);

            _dbContext.Entry(category).CurrentValues.SetValues(updatedCategory);
            await _dbContext.SaveChangesAsync();

            return category;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Categories
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
        }



    }
}

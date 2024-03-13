using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly FiestaDbContext _dbContext;

        public CategoryRepository(FiestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> Get()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetWithSubCategories()
        {
            return await _dbContext.Categories
                .Include(c => c.ParentCategory)
                .Include(c => c.SubCategories)
                .Where(c => c.ParentCategory == null)
                .ToListAsync();
        }

        public async Task Add(Guid id, string name, Category parentCategory)
        {
            var categoryToAdd = new Category
            {
                Id = id,
                Name = name,
                ParentCategory = parentCategory
            };

            await _dbContext.Categories.AddAsync(categoryToAdd);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Category updatedCategory)
        {
            await _dbContext.Categories
                .Where(p => p.Id == updatedCategory.Id)
                .ExecuteUpdateAsync(update => update
                    .SetProperty(p => p.Name, updatedCategory.Name)
                    .SetProperty(p => p.ParentCategory, updatedCategory.ParentCategory));
        }

        public async Task Delete(Guid id)
        {
            await _dbContext.Categories
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
        }



    }
}

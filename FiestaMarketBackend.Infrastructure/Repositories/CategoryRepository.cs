using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
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

        public async Task<Result<List<Category>, Error>> GetAsync()
        {
            var categories = await _dbContext.Categories
                .AsNoTracking()
                .ToListAsync();

            if (categories.Count == 0)
                return Result.Failure<List<Category>, Error>(Error.NotFound("Category.NoCategoryToReturn", "No categories to return"));

            return Result.Success<List<Category>, Error>(categories);
        }

        public async Task<Result<Category, Error>> GetByIdAsync(Guid? id)
        {
            var category = await _dbContext.Categories
                .AsNoTracking()
                .SingleOrDefaultAsync(c => c.Id == id);

            if (category is null)
                return Result.Failure<Category, Error>(Error.NotFound("Category.NotFoundById", $"Can't find category with id {id}"));

            return Result.Success<Category, Error>(category);
        }

        public async Task<Result<List<Category>, Error>> GetWithSubCategoriesAsync()
        {
            var categories = await _dbContext.Categories
                .Where(c => c.ParentCategory == null)
                .Include(c => c.SubCategories)
                .AsNoTracking()
                .ToListAsync();

            if (categories.Count == 0)
                return Result.Failure<List<Category>, Error>(Error.NotFound("Category.NoCategoryToReturn", "No categories to return"));

            return Result.Success<List<Category>, Error>(categories);
        }

        public async Task<Result<Guid, Error>> AddAsync(string name, Guid? parentCategoryId)
        {
            try
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

                return Result.Success<Guid, Error>(id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid, Error>(Error.Failure("Category.ErrorAdding", "Error adding category"));
            }

        }

        public async Task<Result<Category, Error>> UpdateAsync(Category updatedCategory)
        {
            var category = await _dbContext.Categories.SingleOrDefaultAsync(p => p.Id == updatedCategory.Id);

            if (category is null)
                return Result.Failure<Category, Error>(Error.NotFound("Category.NotFoundForUpdate", $"Can't find category with id {updatedCategory.Id}"));

            try
            {
                _dbContext.Entry(category).CurrentValues.SetValues(updatedCategory);
                await _dbContext.SaveChangesAsync();

                return Result.Success<Category, Error>(category);
            }
            catch (Exception)
            {
                return Result.Failure<Category, Error>(Error.Failure("Category.ErrorUpdating", "Error updating category"));
            }

        }

        public async Task<UnitResult<Error>> DeleteAsync(Guid id)
        {
            await _dbContext.Categories
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            return UnitResult.Success<Error>();
        }



    }
}

using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FiestaMarketBackend.Infrastructure.Repositories
{
    public class NewsRepository
    {
        private readonly FiestaDbContext _dbContext;

        public NewsRepository(FiestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<News>> GetAsync()
        {
            return await _dbContext.News.AsNoTracking().ToListAsync();
        }


        public async Task<News?> GetByIdAsync(Guid id)
        {
            return await _dbContext.News.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<List<News>> GetByPageAsync(int page, int pageSize)
        {
            return await _dbContext.News
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Guid> AddAsync(News news)
        {
            var id = Guid.NewGuid();
            news.Id = id;

            await _dbContext.News.AddAsync(news);
            await _dbContext.SaveChangesAsync();

            return id;
        }

        public async Task UpdateAsync(News updatedNews)
        {
            await _dbContext.News
                .Where(p => p.Id == updatedNews.Id)
                .ExecuteUpdateAsync(update => update
                    .SetProperty(n => n.Name, updatedNews.Name)
                    .SetProperty(n => n.ShortDescription, updatedNews.ShortDescription)
                    .SetProperty(n => n.DescriptionMarkDown, updatedNews.DescriptionMarkDown));
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.News
                .AsNoTracking()
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}

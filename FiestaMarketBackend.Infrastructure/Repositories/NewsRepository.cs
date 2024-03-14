using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task AddAsync(News news)
        {
            var newsToAdd = new News
            {
                Id = news.Id,
                Name = news.Name,
                ShortDescription = news.ShortDescription,
                DescriptionMarkDown = news.DescriptionMarkDown
            };

            await _dbContext.News.AddAsync(newsToAdd);
            await _dbContext.SaveChangesAsync();
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

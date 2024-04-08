using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
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

        public async Task<Result<List<News>, Error>> GetAsync()
        {
            var result = await _dbContext.News.AsNoTracking().ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<News>, Error>(Error.NotFound("News.NotFound", "No news to return"));

            return Result.Success<List<News>, Error>(result);
        }


        public async Task<Result<News, Error>> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.News.AsNoTracking().SingleOrDefaultAsync(n => n.Id == id);

            if (result is null)
                return Result.Failure<News, Error>(Error.NotFound("News.NotFoundById", $"no users found with id : {id}"));

            return Result.Success<News, Error>(result);
        }

        public async Task<Result<List<News>, Error>> GetByPageAsync(int page, int pageSize)
        {
            var result = await _dbContext.News
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<News>, Error>(Error.NotFound("News.NotFoundByPage", "No news to return"));

            return Result.Success<List<News>, Error>(result);
        }

        public async Task<Result<Guid, Error>> AddAsync(News news)
        {
            try
            {
                var id = Guid.NewGuid();
                news.Id = id;

                await _dbContext.News.AddAsync(news);
                await _dbContext.SaveChangesAsync();

                return Result.Success<Guid, Error>(id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid, Error>(Error.Failure("News.ErrorAdding", "Error adding news"));
            }

        }

        public async Task<Result<News, Error>> UpdateAsync(News updatedNews)
        {
            var result = await _dbContext.News.SingleOrDefaultAsync(p => p.Id == updatedNews.Id);

            if (result is null)
                return Result.Failure<News, Error>(Error.NotFound("News.ErrorUpdating", $"No news found with id {updatedNews.Id}"));

            try
            {
                _dbContext.Entry(result).CurrentValues
                      .SetValues(updatedNews);
                await _dbContext.SaveChangesAsync();

                return Result.Success<News, Error>(result);
            }
            catch (Exception)
            {
                return Result.Failure<News, Error>(Error.Failure("News.ErrorUpdating", "Error updating news"));
            }
        }

        public async Task<UnitResult<Error>> DeleteAsync(Guid id)
        {
            await _dbContext.News
                .AsNoTracking()
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            return Result.Success<Error>();
        }
    }
}

using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace FiestaMarketBackend.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly FiestaDbContext _dbContext;

        public UserRepository(FiestaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Get

        public async Task<Result<List<User>>> GetAsync()
        {
            var result = await _dbContext.Users
                .Include(u => u.Favorite)
                .ThenInclude(f => f.Products)
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .Include(u => u.Addresses)
                .AsNoTracking()
                .ToListAsync();

            if (result.Count == 0)
                return Result.Failure<List<User>>("No users to return");

            return Result.Success(result);
        }

        public async Task<Result<User>> GetByIdAsync(Guid id)
        {
            var result = await _dbContext.Users
                .Include(u => u.Favorite)
                .ThenInclude(f => f.Products)
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .Include(u => u.Addresses)
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == id);

            if (result is null)
                return Result.Failure<User>($"No users with id {id} was found");

            return Result.Success(result);
        }

        private async Task<Result<User>> GetByIdTrackingAsync(Guid id)
        {
            var result = await _dbContext.Users
                .Include(u => u.Favorite)
                .ThenInclude(f => f.Products)
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .Include(u => u.Addresses)
                .SingleOrDefaultAsync(u => u.Id == id);

            if (result is null)
                return Result.Failure<User>($"No users with id {id} was found");

            return Result.Success(result);
        }


        public async Task<Result<Guid>> AddAsync(User user)
        {
            try
            {
                var id = Guid.NewGuid();
                user.Id = id;

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return Result.Success(id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid>("Error adding user");
            }
        }

        public async Task<Result<User>> UpdateAsync(User updatedUser)
        {
            var result = await GetByIdTrackingAsync(updatedUser.Id);

            if (result.IsFailure)
                return Result.Failure<User>(result.Error);

            try
            {
                _dbContext.Entry(result).CurrentValues.SetValues(updatedUser);
                await _dbContext.SaveChangesAsync();

                return Result.Success(result.Value);
            }
            catch (Exception)
            {
                return Result.Failure<User>("Error updating user");
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();

            return Result.Success();
        }

        #endregion

        #region Favorite

        public async Task<Result<Favorite>> GetFavoriteAsync(Guid id)
        {
            var result = await GetByIdAsync(id);

            if (result.IsFailure)
                return Result.Failure<Favorite>(result.Error);

            if(result.Value.Favorite is null)
                return Result.Failure<Favorite>("No favorite items to return");

            return Result.Success(result.Value.Favorite);
        }

        public async Task<Result<Favorite>> AddProductsToFavoriteAsync(Guid id, List<Guid> productsId)
        {
            var result = await GetByIdTrackingAsync(id);

            if (result.IsFailure)
                return Result.Failure<Favorite>(result.Error);

            var products = _dbContext.Products.AsNoTracking().Where(p => productsId.Contains(p.Id)).ToList();

            if (products.Count == 0)
                return Result.Failure<Favorite>("No products with associated id's was found");

            result.Value.Favorite.Products.AddRange(products);
            await _dbContext.SaveChangesAsync();

            return Result.Success(result.Value.Favorite);
        }

        public async Task<Result> DeleteProductsFromFavoriteAsync(Guid id, List<Guid> productsToRemove)
        {
            var result = await GetByIdTrackingAsync(id);

            if (result.IsFailure)
                return Result.Failure(result.Error);

            result.Value.Favorite.Products.RemoveAll(p => productsToRemove.Contains(p.Id));
            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }

        #endregion

        #region Cart

        public async Task<Result<Cart>> GetCartAsync(Guid id)
        {
            var result = await GetByIdAsync(id);

            if (result.IsFailure)
                return Result.Failure<Cart>(result.Error);

            return Result.Success(result.Value.Cart);
        }

        public async Task<Result<Cart>> AddProductsToCartAsync(Guid id, List<CartItem> cartItems)
        {
            var user = await GetByIdTrackingAsync(id);

            if (user.IsFailure)
                return Result.Failure<Cart>(user.Error);

            user.Value.Cart.Items.AddRange(cartItems);
            await _dbContext.SaveChangesAsync();

            return Result.Success(user.Value.Cart);
        }
        public async Task<Result> UpdateQtyInCartAsync(Guid id, List<CartItem> itemsToChange)
        {
            var result = await GetByIdTrackingAsync(id);

            if (result.IsFailure)
                return Result.Failure<User>(result.Error);

            foreach (var item in itemsToChange)
            {
                var itemInCart = result.Value.Cart.Items.FirstOrDefault(i => i.Product.Id == item.Product.Id);
                itemInCart.Quantity = item.Quantity;
            }
            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result> DeleteProductsFromCartAsync(Guid id, List<Guid> productsToRemove)
        {
            var result = await GetByIdTrackingAsync(id);

            if (result.IsFailure)
                return Result.Failure<User>(result.Error);

            result.Value.Cart.Items.RemoveAll(ci => productsToRemove.Contains(ci.Product.Id));
            await _dbContext.SaveChangesAsync();

            return Result.Success();
        }


        #endregion

        public async Task<Result<List<Order>>> GetOrdersAsync(Guid id)
        {
            var result = await GetByIdAsync(id);

            return Result.Success(result.Value.Orders);
        }


    }
}

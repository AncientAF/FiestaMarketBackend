using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Result<List<User>, Error>> GetAsync()
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
                return Result.Failure<List<User>, Error>(Error.NotFound("User.NotFound", "No users to return"));

            return Result.Success<List<User>, Error>(result);
        }

        public async Task<Result<User, Error>> GetByIdAsync(Guid id)
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
                return Result.Failure<User, Error>(Error.NotFound("User.NotFoundById", $"No users with id {id} was found"));

            return Result.Success<User, Error>(result);
        }

        private async Task<Result<User, Error>> GetByIdTrackingAsync(Guid id)
        {
            var result = await _dbContext.Users
                .Include(u => u.Favorite)
                .ThenInclude(f => f.Products)
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .Include(u => u.Addresses)
                .SingleOrDefaultAsync(u => u.Id == id);

            if (result is null)
                return Result.Failure<User, Error>(Error.NotFound("User.NotFoundById", $"No users with id {id} was found"));

            return Result.Success<User, Error>(result);
        }


        public async Task<Result<Guid, Error>> AddAsync(User user)
        {
            try
            {
                var id = Guid.NewGuid();
                user.Id = id;

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return Result.Success<Guid, Error>(id);
            }
            catch (Exception)
            {
                return Result.Failure<Guid, Error>(Error.Failure("User.ErrorAdding", "Error adding user"));
            }
        }

        public async Task<Result<User, Error>> UpdateAsync(User updatedUser)
        {
            var result = await GetByIdTrackingAsync(updatedUser.Id);

            if (result.IsFailure)
                return Result.Failure<User, Error>(result.Error);

            try
            {
                _dbContext.Entry(result).CurrentValues.SetValues(updatedUser);
                await _dbContext.SaveChangesAsync();

                return Result.Success<User, Error>(result.Value);
            }
            catch (Exception)
            {
                return Result.Failure<User, Error>(Error.Failure("User.ErrorUpdating", "Error updating user"));
            }
        }

        public async Task<UnitResult<Error>> DeleteAsync(Guid id)
        {
            await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();

            return Result.Success<Error>();
        }

        #endregion

        #region Favorite

        public async Task<Result<Favorite, Error>> GetFavoriteAsync(Guid id)
        {
            var result = await GetByIdAsync(id);

            if (result.IsFailure)
                return Result.Failure<Favorite, Error>(result.Error);

            //if(result.Value.Favorite is null || result.Value.Favorite.Products is null || result.Value.Favorite.Products.Any())
            //    return Result.Failure<Favorite, Error>(Error.NotFound("User.NoFavoriteItems", "No favorite items to return"));

            return Result.Success<Favorite, Error>(result.Value.Favorite);
        }

        public async Task<Result<Favorite, Error>> AddProductsToFavoriteAsync(Guid id, List<Guid> productsId)
        {
            var result = await GetByIdTrackingAsync(id);

            if (result.IsFailure)
                return Result.Failure<Favorite, Error>(result.Error);

            var products = _dbContext.Products.AsNoTracking().Where(p => productsId.Contains(p.Id)).ToList();

            if (products.Count == 0)
                return Result.Failure<Favorite, Error>(Error.NotFound("User.ProductsNotFound", "No products with associated id's was found"));

            result.Value.Favorite.Products.AddRange(products);
            await _dbContext.SaveChangesAsync();

            return Result.Success<Favorite, Error>(result.Value.Favorite);
        }

        public async Task<UnitResult<Error>> DeleteProductsFromFavoriteAsync(Guid id, List<Guid> productsToRemove)
        {
            var result = await GetByIdTrackingAsync(id);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            result.Value.Favorite.Products.RemoveAll(p => productsToRemove.Contains(p.Id));
            await _dbContext.SaveChangesAsync();

            return UnitResult.Success<Error>();
        }

        #endregion

        #region Cart

        public async Task<Result<Cart, Error>> GetCartAsync(Guid id)
        {
            var result = await GetByIdAsync(id);

            if (result.IsFailure)
                return Result.Failure<Cart, Error>(result.Error);

            return Result.Success<Cart, Error>(result.Value.Cart);
        }

        public async Task<Result<Cart, Error>> AddProductsToCartAsync(Guid id, List<CartItem> cartItems)
        {
            var user = await GetByIdTrackingAsync(id);

            if (user.IsFailure)
                return Result.Failure<Cart, Error>(user.Error);

            user.Value.Cart.Items.AddRange(cartItems);
            await _dbContext.SaveChangesAsync();

            return Result.Success<Cart, Error>(user.Value.Cart);
        }
        public async Task<Result<Cart, Error>> UpdateQtyInCartAsync(Guid id, List<CartItem> itemsToChange)
        {
            var result = await GetByIdTrackingAsync(id);

            if (result.IsFailure)
                return Result.Failure<Cart, Error>(result.Error);

            foreach (var item in itemsToChange)
            {
                var itemInCart = result.Value.Cart.Items.FirstOrDefault(i => i.Product.Id == item.Product.Id);
                itemInCart.Quantity = item.Quantity;
            }
            await _dbContext.SaveChangesAsync();

            return Result.Success<Cart, Error>(result.Value.Cart);
        }

        public async Task<UnitResult<Error>> DeleteProductsFromCartAsync(Guid id, List<Guid> productsToRemove)
        {
            var result = await GetByIdTrackingAsync(id);

            if (result.IsFailure)
                return UnitResult.Failure(result.Error);

            result.Value.Cart.Items.RemoveAll(ci => productsToRemove.Contains(ci.Product.Id));
            await _dbContext.SaveChangesAsync();

            return UnitResult.Success<Error>();
        }


        #endregion

        public async Task<Result<List<Order>, Error>> GetOrdersAsync(Guid id)
        {
            var result = await GetByIdAsync(id);

            return Result.Success<List<Order>, Error>(result.Value.Orders);
        }


    }
}

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

        public async Task<List<User>> GetAsync()
        {
            return await _dbContext.Users
                .Include(u => u.Favorite)
                .ThenInclude(f => f.Products)
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .Include(u => u.Addresses)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users
                .Include(u => u.Favorite)
                .ThenInclude(f => f.Products)
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .Include(u => u.Addresses)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        private async Task<User?> GetByIdTrackingAsync(Guid id)
        {
            return await _dbContext.Users
                .Include(u => u.Favorite)
                .ThenInclude(f => f.Products)
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task<Guid> AddAsync(User user)
        {
            var id = Guid.NewGuid();
            user.Id = id;

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return id;
        }

        public async Task<User> UpdateAsync(User updatedUser)
        {
            var user = await GetByIdTrackingAsync(updatedUser.Id);

            _dbContext.Entry(user).CurrentValues.SetValues(updatedUser);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }

        #endregion

        #region Favorite

        public async Task<Favorite> GetFavoriteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            return user.Favorite;
        }

        public async Task<Favorite> AddProductsToFavoriteAsync(Guid id, List<Guid> productsId)
        {
            var user = await GetByIdTrackingAsync(id);
            if (user.Favorite == null)
                user.Favorite = new Favorite();

            var products = _dbContext.Products.AsNoTracking().Where(p => productsId.Contains(p.Id)).ToList();
            user.Favorite.Products.AddRange(products);
            await _dbContext.SaveChangesAsync();

            return user.Favorite;
        }

        public async Task DeleteProductsFromFavoriteAsync(Guid id, List<Guid> productsToRemove)
        {
            var user = await GetByIdTrackingAsync(id);
            user.Favorite.Products.RemoveAll(p => productsToRemove.Contains(p.Id));
            await _dbContext.SaveChangesAsync();
        }

        #endregion

        #region Cart

        public async Task<Cart> GetCartAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            return user.Cart;
        }

        public async Task<Cart> AddProductsToCartAsync(Guid id, List<CartItem> cartItems)
        {
            var user = await GetByIdTrackingAsync(id);
            user.Cart.Items.AddRange(cartItems);
            await _dbContext.SaveChangesAsync();

            return user.Cart;
        }
        public async Task UpdateQtyInCartAsync(Guid id, List<CartItem> itemsToChange)
        {
            var user = await GetByIdTrackingAsync(id);
            foreach (var item in itemsToChange)
            {
                var itemInCart = user.Cart.Items.FirstOrDefault(i => i.Product.Id == item.Product.Id);
                itemInCart.Quantity = item.Quantity;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductsFromCartAsync(Guid id, List<Guid> productsToRemove)
        {
            var user = await GetByIdTrackingAsync(id);
            user.Cart.Items.RemoveAll(ci => productsToRemove.Contains(ci.Product.Id));
            await _dbContext.SaveChangesAsync();
        }


        #endregion

        public async Task<List<Order>> GetOrdersAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            return user.Orders;
        }


    }
}

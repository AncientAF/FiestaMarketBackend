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

        public async Task<List<User>> GetAsync()
        {
            return await _dbContext.Users
                .Include(u => u.Favorite)
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
                .Include(u => u.Orders)
                .Include(u => u.Cart)
                .Include(u => u.Addresses)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(User updatedUser)
        {
            await _dbContext.Users
                .Where(u => u.Id == updatedUser.Id)
                .ExecuteUpdateAsync(update => update
                    .SetProperty(u => u.Name, updatedUser.Name)
                    .SetProperty(u => u.SurName, updatedUser.SurName)
                    .SetProperty(u => u.Email, updatedUser.Email)
                    .SetProperty(u => u.Addresses, updatedUser.Addresses)
                    .SetProperty(u => u.Orders, updatedUser.Orders)
                    .SetProperty(u => u.Cart, updatedUser.Cart)
                    .SetProperty(u => u.Password, updatedUser.Password)
                    .SetProperty(u => u.PhoneNumber, updatedUser.PhoneNumber)
                    .SetProperty(u => u.Favorite, updatedUser.Favorite));


        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbContext.Users
                .AsNoTracking()
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Favorite> GetFavoriteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            return user.Favorite;
        }
        public async Task<Cart> GetCartAsync(Guid id)
        {
            var user = await GetByIdAsync(id);

            return user.Cart;
        }

        public async Task AddProductsToFavoriteAsync(Guid id, List<Product> products)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            user.Favorite.Products.AddRange(products);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductsFromFavoriteAsync(Guid id, List<Guid> productsToRemove)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            user.Favorite.Products.RemoveAll(p => productsToRemove.Contains(p.Id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddProductsToCartAsync(Guid id, List<CartItem> cartItems)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            user.Cart.Items.AddRange(cartItems);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductsFromCartAsync(Guid id, List<Guid> productsToRemove)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            user.Cart.Items.RemoveAll(ci => productsToRemove.Contains(ci.Product.Id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateQtyInCartAsync(Guid id, List<CartItem> itemsToChange)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            foreach (var item in itemsToChange)
            {
                var itemInCart = user.Cart.Items.FirstOrDefault(i => i.Product.Id == item.Product.Id);
                itemInCart.Quantity = item.Quantity;
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}

using CSharpFunctionalExtensions;
using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Core.Enums;

namespace FiestaMarketBackend.Core.Repositories
{
    public interface IUserRepository
    {
        Task<Result<Guid, Error>> AddAsync(User user, List<int> roles);
        Task<Result<Cart, Error>> AddProductsToCartAsync(Guid id, List<CartItem> cartItems);
        Task<Result<Favorite, Error>> AddProductsToFavoriteAsync(Guid id, List<Guid> productsId);
        Task<UnitResult<Error>> DeleteAsync(Guid id);
        Task<UnitResult<Error>> DeleteProductsFromCartAsync(Guid id, List<Guid> productsToRemove);
        Task<UnitResult<Error>> DeleteProductsFromFavoriteAsync(Guid id, List<Guid> productsToRemove);
        Task<Result<List<User>, Error>> GetAsync();
        Task<Result<User, Error>> GetByEmail(string email);
        Task<Result<User, Error>> GetByIdAsync(Guid id);
        Task<Result<Cart, Error>> GetCartAsync(Guid id);
        Task<Result<Favorite, Error>> GetFavoriteAsync(Guid id);
        Task<Result<List<Order>, Error>> GetOrdersAsync(Guid id);
        Task<HashSet<PermissionEnum>> GetUserPermissions(Guid id);
        Task<Result<User, Error>> UpdateAsync(User updatedUser);
        Task<Result<Cart, Error>> UpdateQtyInCartAsync(Guid id, List<CartItem> itemsToChange);
    }
}
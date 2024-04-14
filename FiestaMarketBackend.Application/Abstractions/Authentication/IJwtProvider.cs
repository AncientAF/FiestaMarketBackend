namespace FiestaMarketBackend.Application.Abstractions.Authentication
{
    using FiestaMarketBackend.Core.Entities;
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}
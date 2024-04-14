namespace FiestaMarketBackend.Infrastructure.Authentication
{
    public class JwtOptions
    {
        public required string SecretKey { get; set; }
        public int ExpiresHours { get; set; }
    }
}

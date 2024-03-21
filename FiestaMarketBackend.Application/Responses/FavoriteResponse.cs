namespace FiestaMarketBackend.Application.Responses
{
    public class FavoriteResponse
    {
        public Guid Id { get; set; }
        public List<ProductResponse> Products { get; set; }
    }
}

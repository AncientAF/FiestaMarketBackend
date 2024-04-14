namespace FiestaMarketBackend.Application.Responses
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<CategoryResponse>? SubCategories { get; set; }
    }
}

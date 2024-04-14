namespace FiestaMarketBackend.Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Category? ParentCategory { get; set; }
        public List<Category>? SubCategories { get; set; }
    }
}

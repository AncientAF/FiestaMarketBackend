namespace FiestaMarketBackend.Application.Responses
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public Category ParentCategory { get; set; }
        public List<CategoryResponse> SubCategories { get; set; }
    }
}

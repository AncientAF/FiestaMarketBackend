namespace FiestaMarketBackend.Core.Entities
{
    public class Catalog
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public List<Image>? Images { get; set; }
    }
}

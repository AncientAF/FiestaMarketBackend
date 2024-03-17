namespace FiestaMarketBackend.Core.Entities
{
    public class Catalog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image>? Images { get; set; }
    }
}

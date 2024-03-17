using FiestaMarketBackend.Core.Enums;

namespace FiestaMarketBackend.Core.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Catalog Catalog { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageType Type { get; set; }
    }
}

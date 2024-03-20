using FiestaMarketBackend.Core.Enums;

namespace FiestaMarketBackend.Core.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? CatalogId { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
    }
}

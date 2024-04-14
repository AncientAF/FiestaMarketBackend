namespace FiestaMarketBackend.Core.Entities
{
    public class News
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string ShortDescription { get; set; }
        public required string DescriptionMarkDown { get; set; }
        public DateTime? DatePublished { get; set; }
    }
}

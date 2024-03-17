namespace FiestaMarketBackend.Core.Entities
{
    public class News
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionMarkDown { get; set; }
        public DateTime? DatePublished { get; set; }
    }
}

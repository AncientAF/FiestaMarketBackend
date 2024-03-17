namespace FiestaMarketBackend.Application.Responses
{
    public class NewsResponse
    {
        public NewsResponse(Guid id, string name, string shortDescription, string descriptionMarkDown, DateTime datePublished)
        {
            Id = id;
            Name = name;
            ShortDescription = shortDescription;
            DescriptionMarkDown = descriptionMarkDown;
            DatePublished = datePublished;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionMarkDown { get; set; }
        public DateTime DatePublished { get; set; }
    }
}

namespace FiestaMarketBackend.Core.Entities
{
    public record Image
    {
        public required Guid Id { get; set; }
        public required string Path { get; set; }
        public required string Url { get; set; }
    }
}

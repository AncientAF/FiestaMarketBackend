namespace FiestaMarketBackend.Core.Entities
{
    public record Address
    {
        public string Details { get; set; }
        public required string ContactPerson { get; set; }
        public required string DeliveryAddress { get; set; }
        public required string PhoneNumber { get; set; }
    }
}

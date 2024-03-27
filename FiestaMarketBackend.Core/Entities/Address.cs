namespace FiestaMarketBackend.Core.Entities
{
    public class Address
    {
        public string? Details { get; set; }
        public string? ContactPerson { get; set; }
        public required string DeliveryAddress { get; set; }
        public required string PhoneNumber { get; set; }
    }
}

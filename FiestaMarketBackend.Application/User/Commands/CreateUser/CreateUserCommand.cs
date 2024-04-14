using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;
using FiestaMarketBackend.Core.Entities;

namespace FiestaMarketBackend.Application.User
{
    public class CreateUserCommand : ICommand<Result<Guid, Error>>
    {
        public required string Name { get; set; }
        public required string SurName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public List<Address>? Addresses { get; set; }
        public required List<int> Roles { get; set; }
    }
}

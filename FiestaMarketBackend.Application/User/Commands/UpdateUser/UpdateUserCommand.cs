using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    using CSharpFunctionalExtensions;
    using FiestaMarketBackend.Application.Abstractions.Messaging;
    using FiestaMarketBackend.Application.Responses;
    using FiestaMarketBackend.Core;
    using FiestaMarketBackend.Core.Entities;
    public class UpdateUserCommand : ICommand<Result<UserResponse, Error>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public List<Address>? Addresses { get; set; }
        public Favorite? Favorite { get; set; }
        public Cart? Cart { get; set; }
        public List<Order>? Orders { get; set; }
    }
}

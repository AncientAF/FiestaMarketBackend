using FiestaMarketBackend.Core.Entities;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address>? Addresses { get; set; }
    }
}

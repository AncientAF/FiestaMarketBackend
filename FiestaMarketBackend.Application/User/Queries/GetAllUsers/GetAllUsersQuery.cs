using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Application.Responses;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User.Queries
{
    public class GetAllUsersQuery : IQuery<Result<List<UserResponse>, Error>>
    {
    }
}

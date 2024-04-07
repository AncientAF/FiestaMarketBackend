using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;
using MediatR;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromFavoriteCommand : ICommand<UnitResult<Error>>
    {
        public Guid UserId { get; set; }
        public required List<Guid> Items { get; set; }
    }
}

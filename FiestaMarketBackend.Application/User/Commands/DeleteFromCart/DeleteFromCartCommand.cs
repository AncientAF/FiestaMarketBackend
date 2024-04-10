﻿using CSharpFunctionalExtensions;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Application.Abstractions.Messaging;
using FiestaMarketBackend.Core;

namespace FiestaMarketBackend.Application.User.Commands
{
    public class DeleteFromCartCommand : IInvalidateCacheCommand<UnitResult<Error>>
    {
        public Guid Id { get; set; }
        public required List<Guid> Items { get; set; }
        public string[] Keys => [$"user-by-id-{Id}"];
    }
}

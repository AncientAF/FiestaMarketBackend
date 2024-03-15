﻿using FiestaMarketBackend.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    internal class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
    {
        private readonly NewsRepository _newsRepository;

        public DeleteNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.DeleteAsync(request.Id);

            return;
        }
    }
}

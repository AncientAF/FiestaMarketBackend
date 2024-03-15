using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.News.Commands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand>
    {
        private readonly NewsRepository _newsRepository;

        public CreateNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.AddAsync(request.Adapt<News>());

            return;
        }
    }
}

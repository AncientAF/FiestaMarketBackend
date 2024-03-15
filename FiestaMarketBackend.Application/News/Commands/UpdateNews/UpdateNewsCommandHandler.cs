using FiestaMarketBackend.Core.Entities;
using FiestaMarketBackend.Infrastructure.Repositories;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.News.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand>
    {
        private readonly NewsRepository _newsRepository;

        public UpdateNewsCommandHandler(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            await _newsRepository.UpdateAsync(request.Adapt<News>());

            return;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest
    {
        public DeleteNewsCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.News.Commands.CreateNews
{
    public class CreateNewsCommand : IRequest
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string DescriptionMarkDown { get; set; }
    }
}

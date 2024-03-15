using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

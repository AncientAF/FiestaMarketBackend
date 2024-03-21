using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Core.Entities
{
    public class Favorite
    {
        public Guid Id { get; set; }
        public List<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Core.Entities
{
    public class Catalog
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public bool InUse { get; set; }
        public bool Access { get; set; }
        public List<Image> Images { get; set; }
    }
}

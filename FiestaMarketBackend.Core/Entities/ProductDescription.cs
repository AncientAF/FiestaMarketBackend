﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Core.Entities
{
    public class ProductDescription
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public string Text { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public string Games { get; set; }
    }
}

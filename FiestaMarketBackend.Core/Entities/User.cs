﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address> Addresses { get; set; }
        public Favorite Favorite { get; set; }
        public Cart Cart { get; set; }
        public List<Order> Orders { get; set; }
    }
}
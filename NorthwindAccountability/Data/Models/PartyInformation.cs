﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAccountability.Data.Models
{
    public class PartyInformation
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ShippingAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}

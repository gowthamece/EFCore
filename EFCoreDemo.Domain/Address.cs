﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.Domain
{
   public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

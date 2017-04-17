﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class Customer
    {
        public long ID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public bool Activated { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
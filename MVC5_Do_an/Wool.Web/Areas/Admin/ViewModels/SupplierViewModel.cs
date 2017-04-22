﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wool.Web.Areas.Admin.ViewModels
{
    public class SupplierViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
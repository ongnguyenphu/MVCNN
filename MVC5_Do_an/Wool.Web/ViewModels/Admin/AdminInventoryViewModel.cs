using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wool.Web.ViewModels.Admin
{
    public class AdminInventoryViewModel
    {
        public string Group { get; set; }

        public double Value { get; set; }

        public int Count { get; set; }

        public double MinPrice { get; set; }

        public double MaxPrice { get; set; }

        public double Average { get; set; }
    }
}
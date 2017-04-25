using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wool.Web.ViewModels.Admin
{
    public class AdminProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UnitBrief { get; set; }
        public double UnitPrice { get; set; }
        public string Image { get; set; }
        public DateTime ProductDate { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public bool Special { get; set; }
        public bool Latest { get; set; }
        public long Views { get; set; }
        public long CategoryID { get; set; }
        public long SupplierID { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
    }
}
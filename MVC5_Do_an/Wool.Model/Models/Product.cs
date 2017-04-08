using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class Product
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string UnitBrief { get; set; }
        public double UnitPrice { get; set; }
        public string Image { get; set; }
        public DateTime ProductDate{ get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public long CategoryID { get; set; }
        public long SupplierID { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public bool Special { get; set; }
        public bool Latest { get; set; }
        public long Views { get; set; }
        

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }


    }
}

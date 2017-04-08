using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class OrderDetail
    {
        public long ID { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}

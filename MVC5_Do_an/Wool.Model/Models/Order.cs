using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class Order
    {
        public long ID { get; set; }
        public long CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequireDate { get; set; }
        public string Receiver { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
    }
}

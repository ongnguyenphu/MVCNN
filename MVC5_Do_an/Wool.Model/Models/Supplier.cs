using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class Supplier
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}

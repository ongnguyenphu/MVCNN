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
        public string Description { get; set; }
        public bool Status { get; set; }
        public long Condition { get; set; }
        public long Brand { get; set; }
        public double Price { get; set; }

        public long CategoryID { get; set; }
        public Category Category { get; set; }

    }
}

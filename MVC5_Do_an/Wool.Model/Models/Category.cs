using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class Category
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string NameVN { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public virtual ICollection<Product> Products { get; set; }


        public Category()
        {
            DateCreated = DateTime.Now;
            this.Products = new HashSet<Product>();
        }
    }
}

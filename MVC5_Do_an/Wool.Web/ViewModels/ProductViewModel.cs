using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wool.Web.ViewModels
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public long CategoryId { get; set; }
    }
}
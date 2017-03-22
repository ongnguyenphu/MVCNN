using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wool.Web.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
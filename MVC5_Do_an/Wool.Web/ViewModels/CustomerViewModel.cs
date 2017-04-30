using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wool.Web.ViewModels
{
    public class CustomerViewModel
    {
        public long ID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public bool Activated { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wool.Model
{
    public class Master
    {
        public Master()
        {
            this.MasterRoles = new HashSet<MasterRole>();
        }

        public long ID { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<MasterRole> MasterRoles { get; set; }
    }
}

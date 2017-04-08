using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration() {
            ToTable("Orders");
            Property(master => master.OrderDate).IsRequired();
            Property(master => master.RequireDate).IsRequired();
            Property(master => master.Receiver).IsRequired().HasMaxLength(50);
            Property(master => master.Address).IsRequired().HasMaxLength(60);
            Property(master => master.Description).IsRequired().HasMaxLength(1000);
            Property(master => master.Amount).IsRequired();
        }
    }
}

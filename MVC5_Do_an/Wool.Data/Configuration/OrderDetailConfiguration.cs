using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Data.Configuration
{
    public class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
    {
        public OrderDetailConfiguration() {
            ToTable("OrderDetails");
            Property(master => master.UnitPrice).IsRequired();
            Property(master => master.Quantity).IsRequired();
            Property(master => master.Discount).IsRequired();
        }
    }
}

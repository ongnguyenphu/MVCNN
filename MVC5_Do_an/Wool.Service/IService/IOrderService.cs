using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Service
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderByID(long id);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);

        void SaveOrder();
    }
}

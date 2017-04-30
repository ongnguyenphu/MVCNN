using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Data.Repositories;
using Wool.Model;

namespace Wool.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IOrderService Members

        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetAll();
        }

        public Order GetOrderByID(long id)
        {
            Order order = orderRepository.GetById(id);
            return order;
        }

        public void CreateOrder(Order order)
        {
            orderRepository.Add(order);
        }

        public void DeleteOrder(Order order)
        {
            orderRepository.Delete(order);
        }

        public void UpdateOrder(Order order)
        {
            orderRepository.Update(order);
        }

        public void SaveOrder()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}

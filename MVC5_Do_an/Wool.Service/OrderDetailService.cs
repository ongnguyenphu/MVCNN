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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            this.orderDetailRepository = orderDetailRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IOrderDetailService Members

        public IEnumerable<OrderDetail> GetOrderDetails()
        {
            return orderDetailRepository.GetAll();
        }

        
        public void CreateOrderDetail(OrderDetail orderDetail)
        {
            orderDetailRepository.Add(orderDetail);
        }

        public void DeleteOrderDetail(OrderDetail orderDetail)
        {
            orderDetailRepository.Delete(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            orderDetailRepository.Update(orderDetail);
        }

        public void SaveOrderDetail()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}

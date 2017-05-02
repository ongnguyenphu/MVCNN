using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.ViewModels.Admin;

namespace Wool.Web.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;

        public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            this.orderService = orderService;
            this.customerService = customerService;
        }

        private void LoadOrderAndCustomer()
        {
            var customers = customerService.GetCustomers().ToList();
            var customersViewModel = Mapper.Map<IEnumerable<Customer>, IEnumerable<AdminCustomerViewModel>>(customers);
            ViewBag.CustomerId = new SelectList(customersViewModel, "Id", "Fullname");

            var orders = orderService.GetOrders().ToList();
            var ordersViewModel = Mapper.Map<IEnumerable<Order>, IEnumerable<AdminOrderViewModel>>(orders);
            ViewBag.Items = ordersViewModel;
        }

        public ActionResult Index()
        {
            var model = new AdminOrderViewModel();
            LoadOrderAndCustomer();
            return View(model);
        }

        public ActionResult Insert(AdminOrderViewModel model)
        {
            try
            {
                var order = Mapper.Map<AdminOrderViewModel, Order>(model);
                orderService.CreateOrder(order);
                orderService.SaveOrder();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            LoadOrderAndCustomer();
            return View("Index");
        }

        public ActionResult Update(AdminOrderViewModel model)
        {
            try
            {
                var order = Mapper.Map<AdminOrderViewModel, Order>(model);
                orderService.UpdateOrder(order);
                orderService.SaveOrder();
                ModelState.AddModelError("", "Cập nhâtk thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            LoadOrderAndCustomer();
            return View("Index");
        }

        public ActionResult Edit(long Id)
        {
            var model = orderService.GetOrderByID(Id);
            LoadOrderAndCustomer();
            return View("Index", model);
        }

        public ActionResult Delete(long Id)
        {
            var customers = customerService.GetCustomers().ToList();
            var customersViewModel = Mapper.Map<IEnumerable<Customer>, IEnumerable<AdminCustomerViewModel>>(customers);
            ViewBag.CustomerId = new SelectList(customersViewModel, "Id", "Fullname");
            var model = orderService.GetOrderByID(Id);
            try
            {
                orderService.DeleteOrder(model);
                orderService.SaveOrder();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                customers = customerService.GetCustomers().ToList();
                ViewBag.Items = orderService.GetOrders().ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                customers = customerService.GetCustomers().ToList();
                ViewBag.Items = orderService.GetOrders().ToList();
                return View("Index", model);
            }

        }
    }
}
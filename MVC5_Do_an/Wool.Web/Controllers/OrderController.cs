using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.Models;
using Wool.Web.ViewModels;

namespace Wool.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public ActionResult Checkout()
        {
            var user = (Session["user"] as CustomerViewModel);
            var model = new OrderViewModel();

            model.OrderDate = DateTime.Now;
            model.Amount = ShoppingCart.Cart.Amount;
            model.CustomerId = user.ID;
            model.RequireDate = DateTime.Now.AddDays(5);
            model.Receiver = user.FullName;
            return View(model);
        }

        //[HttpPost]
        //public ActionResult Checkout(OrderViewModel orderViewModel)
        //{
        //    try
        //    {
        //        var order = Mapper.Map<OrderViewModel, Order>(orderViewModel);
        //        orderService.CreateOrder(order);
        //        foreach (var p in ShoppingCart.Cart.Items)
        //        {
        //            var orderDetail = new OrderDetail();
        //            orderDetail.ProductId = p.Id;
        //            orderDetail.Order = model;
        //            orderDetail.UnitPrice = p.UnitPrice;
        //            orderDetail.Discount = p.Discount;
        //            dbContext.OrderDetails.Add(orderDetail);
        //        }
        //        orderService.SaveOrder();
        //        ShoppingCart.Cart.Clear();
        //    }
        //    catch
        //    {
        //        ModelState.AddModelError("", "Dat hang khong thanh cong");
        //    }
        //    return RedirectToAction("List", "Order");
        //}

        //public ActionResult Detail(long id)
        //{
        //    var order = orderService.GetOrderByID(id);
        //    return View(order);
        //}

        //public ActionResult List()
        //{
        //    var user = Session["user"] as CustomerViewModel;
        //    var model = dbContext.Orders
        //        .OrderBy(o => o.OrderDate)
        //        .Where(o => o.CustomerId == user.Id).ToList();
        //    return View(model);
        //}

        //public ActionResult ProductList()
        //{
        //    var user = Session["user"] as CustomerViewModel;
        //    var model = dbContext.OrderDetails
        //        .Where(o => o.Order.CustomerId == user.Id)
        //        .Select(d => d.Product)
        //        .Distinct()
        //        .ToList();
        //    return View("../Product/ProductList", model);
        //}
    }
}
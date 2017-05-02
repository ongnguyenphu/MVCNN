using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wool.Service;
using Wool.Web.ViewModels.Admin;

namespace Wool.Web.Infrastructure
{
    public class Statistic
    {
        private readonly IProductService productService;
        private readonly IOrderDetailService orderDetailService;

        public IEnumerable<AdminInventoryViewModel> ProductByCategory()
        {
            var result = productService.GetProducts()
                   .GroupBy(p => p.Category)
                   .Select(g => new AdminInventoryViewModel
                   {
                       Group = g.Key.Name,
                       Value = g.Sum(p => p.UnitPrice * p.Quantity),
                       Count = g.Sum(p => p.Quantity),
                       MinPrice = g.Min(p => p.UnitPrice),
                       MaxPrice = g.Max(p => p.UnitPrice),
                       Average = g.Average(p => p.UnitPrice)
                   });
            return result;
        }

        public IEnumerable<AdminInventoryViewModel> ProductBySupplier()
        {
            var result = productService.GetProducts()
                   .GroupBy(p => p.Supplier)
                   .Select(g => new AdminInventoryViewModel
                   {
                       Group = g.Key.Name,
                       Value = g.Sum(p => p.UnitPrice * p.Quantity),
                       Count = g.Sum(p => p.Quantity),
                       MinPrice = g.Min(p => p.UnitPrice),
                       MaxPrice = g.Max(p => p.UnitPrice),
                       Average = g.Average(p => p.UnitPrice)
                   });
            return result;
        }

        public IEnumerable<AdminInventoryViewModel> RevenueByProduct()
        {
            var result = orderDetailService.GetOrderDetails()
                    .GroupBy(p => p.Product)
                    .Select(g => new AdminInventoryViewModel
                    {
                        Group = g.Key.Name,
                        Value = g.Sum(p => p.UnitPrice * p.Quantity),
                        Count = g.Sum(p => p.Quantity),
                        MinPrice = g.Min(p => p.UnitPrice),
                        MaxPrice = g.Max(p => p.UnitPrice),
                        Average = g.Average(p => p.UnitPrice)
                    });
            return result;
        }

        public IEnumerable<AdminInventoryViewModel> RevenueByCategory()
        {
            var result = orderDetailService.GetOrderDetails()
                    .GroupBy(p => p.Product.Category)
                    .Select(g => new AdminInventoryViewModel
                    {
                        Group = g.Key.Name,
                        Value = g.Sum(p => p.UnitPrice * p.Quantity),
                        Count = g.Sum(p => p.Quantity),
                        MinPrice = g.Min(p => p.UnitPrice),
                        MaxPrice = g.Max(p => p.UnitPrice),
                        Average = g.Average(p => p.UnitPrice)
                    });
            return result;
        }

        public IEnumerable<AdminInventoryViewModel> RevenueBySupplier()
        {
            var result = orderDetailService.GetOrderDetails()
                    .GroupBy(p => p.Product.Supplier)
                    .Select(g => new AdminInventoryViewModel
                    {
                        Group = g.Key.Name,
                        Value = g.Sum(p => p.UnitPrice * p.Quantity),
                        Count = g.Sum(p => p.Quantity),
                        MinPrice = g.Min(p => p.UnitPrice),
                        MaxPrice = g.Max(p => p.UnitPrice),
                        Average = g.Average(p => p.UnitPrice)
                    });
            return result;
        }

        public IEnumerable<AdminInventoryViewModel> RevenueByCustomer()
        {
            var result = orderDetailService.GetOrderDetails()
                    .GroupBy(p => p.Order.Customer)
                    .ToList()
                    .Select(g => new AdminInventoryViewModel
                    {
                        Group = g.Key.ID.ToString(),
                        Value = g.Sum(p => p.UnitPrice * p.Quantity),
                        Count = g.Sum(p => p.Quantity),
                        MinPrice = g.Min(p => p.UnitPrice),
                        MaxPrice = g.Max(p => p.UnitPrice),
                        Average = g.Average(p => p.UnitPrice)
                    });
            return result;
        }

        public IEnumerable<AdminInventoryViewModel> RevenueByYear()
        {
            var result = orderDetailService.GetOrderDetails()
                    .GroupBy(p => p.Order.OrderDate.Year)
                    .ToList()
                    .Select(g => new AdminInventoryViewModel
                    {
                        Group = g.Key.ToString(),
                        Value = g.Sum(p => p.UnitPrice * p.Quantity),
                        Count = g.Sum(p => p.Quantity),
                        MinPrice = g.Min(p => p.UnitPrice),
                        MaxPrice = g.Max(p => p.UnitPrice),
                        Average = g.Average(p => p.UnitPrice)
                    });
            return result;
        }

        public IEnumerable<AdminInventoryViewModel> RevenueByQuarter()
        {
            var result = orderDetailService.GetOrderDetails()
                     .GroupBy(p => Math.Ceiling(1.0 * p.Order.OrderDate.Month / 3))
                     .ToList()
                     .Select(g => new AdminInventoryViewModel
                     {
                         Group = g.Key.ToString(),
                         Value = g.Sum(p => p.UnitPrice * p.Quantity),
                         Count = g.Sum(p => p.Quantity),
                         MinPrice = g.Min(p => p.UnitPrice),
                         MaxPrice = g.Max(p => p.UnitPrice),
                         Average = g.Average(p => p.UnitPrice)
                     });
            return result;
        }

        public IEnumerable<AdminInventoryViewModel> RevenueByMonth()
        {
            var result = orderDetailService.GetOrderDetails()
                    .GroupBy(p => p.Order.OrderDate.Month)
                    .ToList()
                    .Select(g => new AdminInventoryViewModel
                    {
                        Group = g.Key.ToString(),
                        Value = g.Sum(p => p.UnitPrice * p.Quantity),
                        Count = g.Sum(p => p.Quantity),
                        MinPrice = g.Min(p => p.UnitPrice),
                        MaxPrice = g.Max(p => p.UnitPrice),
                        Average = g.Average(p => p.UnitPrice)
                    });
            return result;
        }
    }
}
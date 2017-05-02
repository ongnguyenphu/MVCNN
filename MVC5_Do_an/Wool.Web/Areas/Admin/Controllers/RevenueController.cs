using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Web.Infrastructure;

namespace Wool.Web.Areas.Admin.Controllers
{
    public class RevenueController : Controller
    {
        private readonly Statistic statistic;

        public ActionResult ByProduct()
        {
            var result = statistic.RevenueByProduct();
            return View("Revenue", result);
        }

        public ActionResult ByCategory()
        {
            var result = statistic.RevenueByCategory();
            return View("Revenue", result);
        }


        public ActionResult BySupplier()
        {
            var result = statistic.RevenueBySupplier();
            return View("Revenue", result);
        }


        public ActionResult ByCustomer()
        {
            var result = statistic.RevenueByCustomer();
            return View("Revenue", result);
        }

        public ActionResult ByYear()
        {
            var result = statistic.RevenueByYear();
            return View("Revenue", result);
        }

        public ActionResult ByQuarter()
        {
            var result = statistic.RevenueByQuarter();
            return View("Revenue", result);
        }

        public ActionResult ByMonth()
        {
            var result = statistic.RevenueByMonth();
            return View("Revenue", result);
        }
    }
}
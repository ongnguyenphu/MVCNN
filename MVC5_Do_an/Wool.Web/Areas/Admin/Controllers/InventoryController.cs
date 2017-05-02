using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Service;
using Wool.Web.Infrastructure;

namespace Wool.Web.Areas.Admin.Controllers
{
    public class InventoryController : Controller
    {
        private readonly Statistic statistic;
        public ActionResult ByCategory()
        {
            var result = statistic.ProductByCategory();
            return View("Inventory", result);
        }

        public ActionResult BySupplier()
        {
            var result = statistic.ProductBySupplier();
            return View("Inventory", result);
        }
    }
}
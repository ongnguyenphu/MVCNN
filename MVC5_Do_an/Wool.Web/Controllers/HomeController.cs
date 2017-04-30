using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.ViewModels;

namespace Wool.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;
        private readonly IProductService productService;

        public HomeController(ICategoryService categoryService, ISupplierService supplierService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.supplierService = supplierService;
            this.productService = productService;
        }

        // GET: Home
        public ActionResult Index()
        {
            Session["ShoppingUrl"] = "/Home/Index";

            ViewBag.Suppliers = supplierService.GetSuppliers()
                .Where(s => s.Products.Count >= 4)
                .OrderBy(s => Guid.NewGuid())
                .Take(5)
                .ToList();

            ViewBag.Specials = productService.GetProducts()
                .Where(p => p.Special)
                .OrderBy(s => Guid.NewGuid())
                .ToList();

            ViewBag.Categories = categoryService.GetCategories()
                .Where(s => s.Products.Count >= 5)
                .OrderBy(s => Guid.NewGuid())
                .Take(3)
                .ToList();

            return View();
        }

        public ActionResult _Category()
        {
            IEnumerable<CategoryViewModel> viewModelCategories;
            IEnumerable<Category> categories;

            categories = categoryService.GetCategories().ToList();

            viewModelCategories = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return PartialView(viewModelCategories);
        }

        public ActionResult _Supplier()
        {
            IEnumerable<SupplierViewModel> viewModelSuppliers;
            IEnumerable<Supplier> suppliers;

            suppliers = supplierService.GetSuppliers().ToList();

            viewModelSuppliers = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(suppliers);
            return PartialView(viewModelSuppliers);
        }

    }
}
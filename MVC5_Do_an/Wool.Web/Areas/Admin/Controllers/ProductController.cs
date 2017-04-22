using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.Areas.Admin.ViewModels;

namespace Wool.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;

        public ProductController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.supplierService = supplierService;
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var vmProduct = new ProductViewModel();

            IEnumerable<ProductViewModel> viewModelProducts;
            IEnumerable<Product> products;

            products = productService.GetProducts().ToList();

            var categories = categoryService.GetCategories().ToList();
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");


            var result = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
            ViewBag.Items = result;

            return View(vmProduct);
        }

        public ActionResult Insert(ProductViewModel newProduct)
        {
            if (newProduct != null)
            {
                var file = Request.Files["upImage"];
                if (file.ContentLength > 0)
                {
                    newProduct.Image = file.FileName;
                    file.SaveAs(Server.MapPath("~/images/products/" + file.FileName));
                }
                else
                {
                    newProduct.Image = "Product.png";
                }

                var product = Mapper.Map<ProductViewModel, Product>(newProduct);
                productService.CreateProduct(product);
                productService.SaveProduct();
                ModelState.Clear();
            }
            var products = productService.GetProducts().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);

            var categories = categoryService.GetCategories().ToList();
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");
            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            var categories = categoryService.GetCategories().ToList();
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");
            var product = productService.GetProductByID(id);
            var products = productService.GetProducts().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            return View("Index", productViewModel);
        }

        public ActionResult Delete(long id)
        {
            var categories = categoryService.GetCategories().ToList();
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");

            var product = productService.GetProductByID(id);
            var productViewModel = Mapper.Map<Product, ProductViewModel>(product);
            try
            {
                productService.DeleteProduct(product);
                productService.SaveProduct();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                var products = productService.GetProducts().ToList();
                ViewBag.Items = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                return View("Index", productViewModel);
            }
        }

        public ActionResult Update(ProductViewModel updatedProduct)
        {
            try
            {
                var file = Request.Files["upLogo"];
                if (file.ContentLength > 0)
                {
                    updatedProduct.Image = file.FileName;
                    file.SaveAs(Server.MapPath("~/images/products/" + file.FileName));
                }
                var product = Mapper.Map<ProductViewModel, Product>(updatedProduct);
                productService.UpdateProduct(product);
                productService.SaveProduct();
                ModelState.AddModelError("", "Cap nhat thành công !");
            }
            catch
            {
                ModelState.AddModelError("", "Cap nhat thất bại !");
            }
            var products = productService.GetProducts().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
            var categories = categoryService.GetCategories().ToList();
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");
            return View("Index");
        }
    }
}
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.ViewModels.Admin;

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
            var vmProduct = new AdminProductViewModel();
            IEnumerable<AdminProductViewModel> viewModelProducts;

            LoadCategories();
            LoadSuppliers();
            LoadProducts();

            return View(vmProduct);
        }

        public ActionResult Insert(AdminProductViewModel newProduct)
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

                var product = Mapper.Map<AdminProductViewModel, Product>(newProduct);
                productService.CreateProduct(product);
                productService.SaveProduct();
                ModelState.Clear();
            }
            LoadProducts();
            LoadCategories();
            LoadSuppliers();
            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            LoadCategories();
            LoadSuppliers();
            LoadProducts();
            var product = productService.GetProductByID(id);
            var productViewModel = Mapper.Map<Product, AdminProductViewModel>(product);
            return View("Index", productViewModel);
        }

        public ActionResult Delete(long id)
        {
            var product = productService.GetProductByID(id);
            var productViewModel = Mapper.Map<Product, AdminProductViewModel>(product);
            try
            {
                productService.DeleteProduct(product);
                productService.SaveProduct();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                LoadCategories();
                LoadSuppliers();
                LoadProducts();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                return View("Index", productViewModel);
            }
        }

        public ActionResult Update(AdminProductViewModel updatedProduct)
        {
            try
            {
                var file = Request.Files["upLogo"];
                if (file.ContentLength > 0)
                {
                    updatedProduct.Image = file.FileName;
                    file.SaveAs(Server.MapPath("~/images/products/" + file.FileName));
                }
                var product = Mapper.Map<AdminProductViewModel, Product>(updatedProduct);
                productService.UpdateProduct(product);
                productService.SaveProduct();
                ModelState.AddModelError("", "Cap nhat thành công !");
            }
            catch
            {
                ModelState.AddModelError("", "Cap nhat thất bại !");
            }
            LoadProducts();
            LoadCategories();
            LoadSuppliers();

            return View("Index");
        }

        #region Private Load

        private void LoadCategories()
        {
            List<Category> categories = categoryService.GetCategories().ToList();
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
        }
        private void LoadSuppliers()
        {
            List<Supplier> suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");
        }

        private void LoadProducts()
        {
            IEnumerable<Product> products = productService.GetProducts().ToList();
            IEnumerable<AdminProductViewModel> result = Mapper.Map<IEnumerable<Product>, IEnumerable<AdminProductViewModel>>(products);
            ViewBag.Items = result;
        }

        #endregion


    }
}
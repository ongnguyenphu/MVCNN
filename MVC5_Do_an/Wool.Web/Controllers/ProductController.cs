using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Service;

namespace Wool.Web.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: Product
        public ActionResult ListByCategory(long Id)
        {
            Session["ShoppingUrl"] = "/Product/ListByCategory/" + Id;
            var products = productService.GetProductsByCategory(Id).ToList();
            return View("ProductList", products);
        }

        public ActionResult ListBySupplier(long Id)
        {
            Session["ShoppingUrl"] = "/Product/ListBySupplier/" + Id;

            var products = productService.GetProductsBySupplier(Id).ToList();
            return View("ProductList", products);
        }

        //public ActionResult ListBySpecial(String Id)
        //{
        //    Session["ShoppingUrl"] = "/Product/ListBySpecial/" + Id;

        //    List<Product> model = null;
        //    switch (Id)
        //    {
        //        case "BEST":
        //            model = dbc.Products
        //                .OrderByDescending(p => p.OrderDetails.Sum(d => d.Quantity))
        //                .Take(12)
        //                .ToList();
        //            break;
        //        case "LATEST":
        //            model = dbc.Products
        //                .Where(p => p.Latest == true)
        //                .ToList();
        //            break;
        //        case "VIEW":
        //            model = dbc.Products
        //                .OrderByDescending(p => p.Views)
        //                .Take(12)
        //                .ToList();
        //            break;
        //        case "SPECIAL":
        //            model = dbc.Products
        //                .Where(p => p.Special == true)
        //                .ToList();
        //            break;
        //        case "DISCOUNT":
        //            model = dbc.Products
        //                .Where(p => p.Discount > 0)
        //                .OrderByDescending(p => p.Discount)
        //                .Take(12)
        //                .ToList();
        //            break;
        //    }

        //    return View("ProductList", model);
        //}

        //public ActionResult Search(String Keywords)
        //{
        //    Session["ShoppingUrl"] = "/Product/Search?Keywords=" + Keywords;

        //    var model = dbc.Products
        //        .Where(p => p.Name.Contains(Keywords)
        //            || p.Category.NameVN.Contains(Keywords)
        //            || p.Category.Name.Contains(Keywords))
        //        .ToList();
        //    return View("ProductList", model);
        //}

        //public ActionResult Detail(int Id)
        //{
        //    var model = dbc.Products.Find(Id);

        //    // Tăng số lần xem
        //    model.Views++;
        //    dbc.SaveChanges();

        //    // Ghi nhận hàng đã xem
        //    var cookie = Request.Cookies["Views"];
        //    if (cookie == null)
        //    {
        //        cookie = new HttpCookie("Views");
        //    }
        //    cookie.Values[Id.ToString()] = Id.ToString();
        //    Response.Cookies.Add(cookie);

        //    // Truy vấn hàng đã xem
        //    var Ids = cookie.Values.AllKeys.Select(k => int.Parse(k)).ToList();
        //    ViewBag.Views = dbc.Products.Where(p => Ids.Contains(p.Id));

        //    return View("ProductDetail", model);
        //}
    }
}
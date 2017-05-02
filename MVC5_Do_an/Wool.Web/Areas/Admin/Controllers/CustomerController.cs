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
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: Admin/Customer
        public ActionResult Index()
        {
            var model = new AdminCustomerViewModel();
            return View(model);
        }

        public ActionResult Insert(AdminCustomerViewModel newCustomer)
        {
            var file = Request.Files["upPhoto"];
            if (file.ContentLength > 0)
            {
                newCustomer.Photo = file.FileName;
                file.SaveAs(Server.MapPath("~/images/customers/" + file.FileName));
            }
            else
            {
                newCustomer.Photo = "Customer.png";
            }
            try
            {
                var customer = Mapper.Map<AdminCustomerViewModel, Customer>(newCustomer);

                customerService.CreateCustomer(customer);
                customerService.SaveCustomer();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            //ViewBag.Items = dbc.Customers.ToList();
            return View("Index");
        }

        public ActionResult Update(AdminCustomerViewModel newCustomer)
        {
            var file = Request.Files["upPhoto"];
            if (file.ContentLength > 0)
            {
                newCustomer.Photo = file.FileName;
                file.SaveAs(Server.MapPath("~/Images/Customers/" + file.FileName));
            }
            try
            {
                var customer = Mapper.Map<AdminCustomerViewModel, Customer>(newCustomer);
                customerService.UpdateCustomer(customer);
                customerService.SaveCustomer();
                ModelState.AddModelError("", "Cập nhâtk thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            //ViewBag.Items = dbc.Customers.ToList();
            return View("Index");
        }

        public ActionResult Edit(long Id)
        {
            var model = customerService.GetCustomerByID(Id);
            //ViewBag.Items = dbc.Customers.ToList();
            return View("Index", model);
        }

        public ActionResult Delete(long Id)
        {
            var model = customerService.GetCustomerByID(Id);
            try
            {
                customerService.DeleteCustomer(model);
                customerService.SaveCustomer();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                //ViewBag.Items = dbc.Customers.ToList();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                //ViewBag.Items = dbc.Customers.ToList();
                return View("Index", model);
            }
        }

        public ActionResult GetList(int pageNo = 0, int pageSize = 10)
        {
            IEnumerable<Customer> customers = customerService.GetCustomers()
                                           .OrderBy(c => c.ID)
                                           .Skip(pageNo * pageSize)
                                           .Take(pageSize)
                                           .ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Customer>, IEnumerable<AdminCustomerViewModel>>(customers);
            return PartialView("_List");
        }

        public ActionResult GetPageCount(int pageSize = 10)
        {
            var numberOfCustomer = customerService.GetCustomers().Count();
            var pageCount = Math.Ceiling(1.0 * numberOfCustomer / pageSize);
            return Json(pageCount, JsonRequestBehavior.AllowGet);
        }
    }
}
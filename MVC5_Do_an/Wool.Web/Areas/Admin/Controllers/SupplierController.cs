using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.Areas.Admin.ViewModels;
using Wool.Web.ViewModels;

namespace Wool.Web.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }


        // GET: Admin/Supplier
        public ActionResult Index()
        {
            var vmSupplier = new SupplierViewModel();

            IEnumerable<SupplierViewModel> viewModelSuppliers;
            IEnumerable<Supplier> suppliers;

            suppliers = supplierService.GetSuppliers().ToList();

            ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(suppliers);

            return View(vmSupplier);
        }

        public ActionResult Insert(SupplierViewModel newSupplier)
        {
            if (newSupplier != null)
            {
                var file = Request.Files["upLogo"];
                if (file.ContentLength > 0)
                {
                    newSupplier.Logo = file.FileName;
                    file.SaveAs(Server.MapPath("~/images/suppliers/" + file.FileName));
                }
                else
                {
                    newSupplier.Logo = "Supplier.png";
                }

                var supplier = Mapper.Map<SupplierViewModel, Supplier>(newSupplier);
                supplierService.CreateSupplier(supplier);
                supplierService.SaveSupplier();
                ModelState.Clear();
            }
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(suppliers);

            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            var supplier = supplierService.GetSupplierByID(id);
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(suppliers);
            var supplierViewModel = Mapper.Map<Supplier, SupplierViewModel>(supplier);
            return View("Index", supplierViewModel);
        }

        public ActionResult Delete(long id)
        {
            var supplier = supplierService.GetSupplierByID(id);
            var supplierViewModel = Mapper.Map<Supplier, SupplierViewModel>(supplier);
            try
            {
                supplierService.DeleteSupplier(supplier);
                supplierService.SaveSupplier();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                var suppliers = supplierService.GetSuppliers().ToList();
                ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(suppliers);
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                return View("Index", supplierViewModel);
            }
        }

        public ActionResult Update(SupplierViewModel updatedSupplier)
        {
            try
            {
                var file = Request.Files["upLogo"];
                if (file.ContentLength > 0)
                {
                    updatedSupplier.Logo = file.FileName;
                    file.SaveAs(Server.MapPath("~/images/suppliers/" + file.FileName));
                }
                var supplier = Mapper.Map<SupplierViewModel, Supplier>(updatedSupplier);
                supplierService.UpdateSupplier(supplier);
                supplierService.SaveSupplier();
                ModelState.AddModelError("", "Cap nhat thành công !");
            }
            catch
            {
                ModelState.AddModelError("", "Cap nhat thất bại !");
            }
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(suppliers);
            return View("Index");
        }
    }
}
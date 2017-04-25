using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;
using Wool.Web.ViewModels.Admin;

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
            var vmSupplier = new AdminSupplierViewModel();

            IEnumerable<AdminSupplierViewModel> viewModelSuppliers;
            IEnumerable<Supplier> suppliers;

            suppliers = supplierService.GetSuppliers().ToList();

            ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<AdminSupplierViewModel>>(suppliers);

            return View(vmSupplier);
        }

        public ActionResult Insert(AdminSupplierViewModel newSupplier)
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

                var supplier = Mapper.Map<AdminSupplierViewModel, Supplier>(newSupplier);
                supplierService.CreateSupplier(supplier);
                supplierService.SaveSupplier();
                ModelState.Clear();
            }
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<AdminSupplierViewModel>>(suppliers);

            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            var supplier = supplierService.GetSupplierByID(id);
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<AdminSupplierViewModel>>(suppliers);
            var supplierViewModel = Mapper.Map<Supplier, AdminSupplierViewModel>(supplier);
            return View("Index", supplierViewModel);
        }

        public ActionResult Delete(long id)
        {
            var supplier = supplierService.GetSupplierByID(id);
            var supplierViewModel = Mapper.Map<Supplier, AdminSupplierViewModel>(supplier);
            try
            {
                supplierService.DeleteSupplier(supplier);
                supplierService.SaveSupplier();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");
                var suppliers = supplierService.GetSuppliers().ToList();
                ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<AdminSupplierViewModel>>(suppliers);
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                return View("Index", supplierViewModel);
            }
        }

        public ActionResult Update(AdminSupplierViewModel updatedSupplier)
        {
            try
            {
                var file = Request.Files["upLogo"];
                if (file.ContentLength > 0)
                {
                    updatedSupplier.Logo = file.FileName;
                    file.SaveAs(Server.MapPath("~/images/suppliers/" + file.FileName));
                }
                var supplier = Mapper.Map<AdminSupplierViewModel, Supplier>(updatedSupplier);
                supplierService.UpdateSupplier(supplier);
                supplierService.SaveSupplier();
                ModelState.AddModelError("", "Cap nhat thành công !");
            }
            catch
            {
                ModelState.AddModelError("", "Cap nhat thất bại !");
            }
            var suppliers = supplierService.GetSuppliers().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Supplier>, IEnumerable<AdminSupplierViewModel>>(suppliers);
            return View("Index");
        }
    }
}
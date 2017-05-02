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
    public class MasterController : Controller
    {
        private readonly IMasterService masterService;

        public MasterController(IMasterService masterService)
        {
            this.masterService = masterService;
        }

        public ActionResult Index()
        {
            var model = new AdminMasterViewModel();
            var listMaster = masterService.GetMasters().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Master>, IEnumerable<AdminMasterViewModel>>(listMaster);
            return View(model);
        }

        public ActionResult Insert(AdminMasterViewModel newMaster)
        {
            try
            {
                var master = Mapper.Map<AdminMasterViewModel, Master>(newMaster);
                masterService.CreateMaster(master);
                masterService.SaveMaster();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            var listMaster = masterService.GetMasters().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Master>, IEnumerable<AdminMasterViewModel>>(listMaster);
            return View("Index");
        }

        public ActionResult Update(AdminMasterViewModel newMaster)
        {
            try
            {
                var master = Mapper.Map<AdminMasterViewModel, Master>(newMaster);
                masterService.UpdateMaster(master);
                masterService.SaveMaster();
                ModelState.AddModelError("", "Cập nhât thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            var listMaster = masterService.GetMasters().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Master>, IEnumerable<AdminMasterViewModel>>(listMaster);
            return View("Index");
        }

        public ActionResult Edit(long Id)
        {
            var model = masterService.GetByID(Id);
            var masterViewModel = Mapper.Map<Master, AdminMasterViewModel>(model);
            var listMaster = masterService.GetMasters().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Master>, IEnumerable<AdminMasterViewModel>>(listMaster);
            return View("Index", masterViewModel);
        }

        public ActionResult Delete(long Id)
        {
            var model = masterService.GetByID(Id);
            try
            {
                masterService.DeleteMaster(model);
                masterService.SaveMaster();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                var listMaster = masterService.GetMasters().ToList();
                ViewBag.Items = Mapper.Map<IEnumerable<Master>, IEnumerable<AdminMasterViewModel>>(listMaster);
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                var listMaster = masterService.GetMasters().ToList();
                ViewBag.Items = Mapper.Map<IEnumerable<Master>, IEnumerable<AdminMasterViewModel>>(listMaster);
                return View("Index", model);
            }
        }
        //-------------------------//
        public ActionResult Login()
        {
            //Session.Remove("Master");
            return View();
        }
        [HttpPost]
        public ActionResult Login(long Id, String Password)
        {
            var master = masterService.GetByID(Id);
            if (master == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            else if (master.Password != Password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập thành công");
                Session["Master"] = master;
            }
            return View();
        }

        public ActionResult Change()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Change(long Id, String Password, String Password1, String Password2)
        {
            var master = masterService.GetByID(Id);
            if (master == null)
            {
                ModelState.AddModelError("", "Sai tên đăng nhập");
            }
            else if (master.Password != Password)
            {
                ModelState.AddModelError("", "Sai mật khẩu");
            }
            else if (Password1 != Password2)
            {
                ModelState.AddModelError("", "Xác nhận sai mật khẩu mới");
            }
            else
            {
                ModelState.AddModelError("", "Đổi mật khẩu thành công");

                master.Password = Password2;
                masterService.UpdateMaster(master);
                masterService.SaveMaster();
                Session["Master"] = master;
            }
            return View();
        }
    }
}
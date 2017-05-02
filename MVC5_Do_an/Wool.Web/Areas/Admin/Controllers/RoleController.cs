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
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public ActionResult Index()
        {
            var model = new AdminRoleViewModel();
            ViewBag.Items = roleService.GetRoles().ToList();
            return View(model);
        }

        private void LoadRole()
        {
            var roles = roleService.GetRoles().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<Role>, IEnumerable<AdminRoleViewModel>>(roles);
        }

        public ActionResult Insert(AdminRoleViewModel model)
        {
            try
            {
                var role = Mapper.Map<AdminRoleViewModel, Role>(model);
                roleService.CreateRole(role);
                roleService.SaveRole();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            LoadRole();
            return View("Index");
        }

        public ActionResult Update(AdminRoleViewModel model)
        {
            try
            {
                var role = Mapper.Map<AdminRoleViewModel, Role>(model);
                roleService.UpdateRole(role);
                roleService.SaveRole();
                ModelState.AddModelError("", "Cập nhât thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            LoadRole();
            return View("Index");
        }

        public ActionResult Edit(long Id)
        {
            var model = roleService.GetByID(Id);
            var role = Mapper.Map<Role, AdminRoleViewModel>(model);
            LoadRole();
            return View("Index", model);
        }

        public ActionResult Delete(long Id)
        {
            var model = roleService.GetByID(Id);
            try
            {
                roleService.DeleteRole(model);
                roleService.SaveRole();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                LoadRole();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                LoadRole();
                return View("Index", model);
            }
        }
    }
}
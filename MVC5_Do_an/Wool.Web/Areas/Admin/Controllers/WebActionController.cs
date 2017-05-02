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
    public class WebActionController : Controller
    {
        private readonly IWebActionService webActionService;

        public WebActionController(IWebActionService webActionService)
        {
            this.webActionService = webActionService;
        }

        private void LoadWebAction()
        {
            var webActions = webActionService.GetWebActions().ToList();
            ViewBag.Items = Mapper.Map<IEnumerable<WebAction>, IEnumerable<AdminWebActionViewModel>>(webActions);
        }

        public ActionResult Index()
        {
            var model = new AdminWebActionViewModel();
            LoadWebAction();
            return View(model);
        }

        public ActionResult Insert(AdminWebActionViewModel model)
        {
            try
            {
                var webAction = Mapper.Map<AdminWebActionViewModel, WebAction>(model);
                webActionService.CreateWebAction(webAction);
                webActionService.SaveWebAction();
                ModelState.Clear();// xóa thông tin trên form
                ModelState.AddModelError("", "Thêm mới thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Thêm mới thất bại");
            }
            LoadWebAction();
            return View("Index");
        }

        public ActionResult Update(AdminWebActionViewModel model)
        {
            try
            {
                var webAction = Mapper.Map<AdminWebActionViewModel, WebAction>(model);
                webActionService.UpdateWebAction(webAction);
                webActionService.SaveWebAction();
                ModelState.AddModelError("", "Cập nhâtk thành công");
            }
            catch
            {
                ModelState.AddModelError("", "Cập nhật thất bại");
            }
            LoadWebAction();
            return View("Index");
        }

        public ActionResult Edit(long Id)
        {
            var model = webActionService.GetByID(Id);
            var webAction = Mapper.Map<WebAction, AdminWebActionViewModel>(model);
            LoadWebAction();
            return View("Index", model);
        }

        public ActionResult Delete(long Id)
        {
            var model = webActionService.GetByID(Id);
            try
            {
                webActionService.DeleteWebAction(model);
                webActionService.SaveWebAction();
                ModelState.Clear();
                ModelState.AddModelError("", "Xóa thành công !");

                LoadWebAction();
                return View("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Xóa thất bại !");
                LoadWebAction();
                return View("Index", model);
            }
        }
    }
}
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
    public class WebActionRoleController : Controller
    {
        private readonly IActionRoleService actionRoleService;
        private readonly IRoleService roleService;
        private readonly IWebActionService webActionService;

        public WebActionRoleController(IActionRoleService actionRoleService, IRoleService roleService, IWebActionService webActionService)
        {
            this.actionRoleService = actionRoleService;
            this.roleService = roleService;
            this.webActionService = webActionService;
        }

        private void LoadRole()
        {
            var roles = roleService.GetRoles().ToList();
            ViewBag.RoleId = new SelectList(roles, "Id", "Name");
        }

        private void LoadWebAction()
        {
            var webActions = webActionService.GetWebActions().ToList();
            ViewBag.WebActions = Mapper.Map<IEnumerable<WebAction>, IEnumerable<AdminWebActionViewModel>>(webActions);
        }

        public ActionResult Index()
        {
            LoadRole();
            LoadWebAction();
            return View();
        }

        public ActionResult GetActions(long roleId)
        {
            var webActionIds = actionRoleService.GetActionRoles()
                .Where(ar => ar.RoleId == roleId)
                .Select(ar => ar.WebActionId)
                .ToList();
            return Json(webActionIds, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(long roleId, long actionId, bool status)
        {
            if (status == true)
            {
                var ar = new ActionRole
                {
                    RoleId = roleId,
                    WebActionId = actionId
                };
                actionRoleService.CreateActionRole(ar);
            }
            else
            {
                var arole = actionRoleService.GetActionRoles()
                    .Single(ar => ar.WebActionId == actionId && ar.RoleId == roleId);
                actionRoleService.DeleteActionRole(arole);
            }
            actionRoleService.SaveActionRole();
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
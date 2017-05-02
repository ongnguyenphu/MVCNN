using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wool.Model;
using Wool.Service;

namespace Wool.Web.Areas.Admin.Controllers
{
    public class MasterRoleController : Controller
    {
        private readonly IMasterService masterService;
        private readonly IRoleService roleService;
        private readonly IMasterRoleService masterRoleService;

        public MasterRoleController(IMasterService masterService, IRoleService roleService, IMasterRoleService masterRoleService)
        {
            this.masterService = masterService;
            this.roleService = roleService;
            this.masterRoleService = masterRoleService;
        }
        public ActionResult Index()
        {
            var listMasters = masterService.GetMasters().ToList();
            ViewBag.MasterId = new SelectList(listMasters, "Id", "FullName");
            ViewBag.Roles = roleService.GetRoles().ToList();
            return View();
        }

        public ActionResult GetRoles(String MasterId)
        {
            var RoleIds = masterRoleService.GetMasterRoles()
                .Where(mr => mr.MasterId == MasterId)
                .Select(mr => mr.RoleId).ToList();
            return Json(RoleIds, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(string masterId, string roleId, bool status)
        {
            if (status == true)
            {
                var mr = new MasterRole
                {
                    MasterId = masterId,
                    RoleId = roleId
                };
                masterRoleService.CreateMasterRole(mr);
            }
            else
            {
                var mrole = masterRoleService.GetMasterRoles()
                    .Single(mr => mr.MasterId == masterId && mr.RoleId == roleId);
                masterRoleService.DeleteMasterRole(mrole);
            }
            masterRoleService.SaveMasterRole();
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}
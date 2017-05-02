using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Data.Repositories;
using Wool.Model;

namespace Wool.Service
{
    public class ActionRoleService : IActionRoleService
    {
        private readonly IActionRoleRepository actionRoleRepository;
        private readonly IUnitOfWork unitOfWork;

        public ActionRoleService(IActionRoleRepository actionRoleRepository, IUnitOfWork unitOfWork)
        {
            this.actionRoleRepository = actionRoleRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IActionRoleService Members

        public IEnumerable<ActionRole> GetActionRoles()
        {
            return actionRoleRepository.GetAll();
        }

        
        public void CreateActionRole(ActionRole actionRole)
        {
            actionRoleRepository.Add(actionRole);
        }

        public void DeleteActionRole(ActionRole actionRole)
        {
            actionRoleRepository.Delete(actionRole);
        }

        public void UpdateActionRole(ActionRole actionRole)
        {
            actionRoleRepository.Update(actionRole);
        }

        public void SaveActionRole()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}

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
    public class MasterRoleService : IMasterRoleService
    {
        private readonly IMasterRoleRepository masterRoleRepository;
        private readonly IUnitOfWork unitOfWork;

        public MasterRoleService(IMasterRoleRepository masterRoleRepository, IUnitOfWork unitOfWork)
        {
            this.masterRoleRepository = masterRoleRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IMasterRoleService Members

        public IEnumerable<MasterRole> GetMasterRoles()
        {
            return masterRoleRepository.GetAll();
        }

        
        public void CreateMasterRole(MasterRole masterRole)
        {
            masterRoleRepository.Add(masterRole);
        }

        public void DeleteMasterRole(MasterRole masterRole)
        {
            masterRoleRepository.Delete(masterRole);
        }

        public void UpdateMasterRole(MasterRole masterRole)
        {
            masterRoleRepository.Update(masterRole);
        }

        public void SaveMasterRole()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}

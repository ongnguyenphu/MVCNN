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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IUnitOfWork unitOfWork;

        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            this.roleRepository = roleRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IRoleService Members

        public IEnumerable<Role> GetRoles()
        {
            return roleRepository.GetAll();
        }

        public Role GetByID(long Id)
        {
            return roleRepository.GetById(Id);
        }


        public void CreateRole(Role role)
        {
            roleRepository.Add(role);
        }

        public void DeleteRole(Role role)
        {
            roleRepository.Delete(role);
        }

        public void UpdateRole(Role role)
        {
            roleRepository.Update(role);
        }

        public void SaveRole()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}

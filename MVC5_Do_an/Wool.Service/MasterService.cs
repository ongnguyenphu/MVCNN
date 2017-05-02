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
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository masterRepository;
        private readonly IUnitOfWork unitOfWork;

        public MasterService(IMasterRepository masterRepository, IUnitOfWork unitOfWork)
        {
            this.masterRepository = masterRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IMasterService Members

        public IEnumerable<Master> GetMasters()
        {
            return masterRepository.GetAll();
        }

        public Master GetByID(long Id)
        {
            return masterRepository.GetById(Id);
        }

        
        public void CreateMaster(Master master)
        {
            masterRepository.Add(master);
        }

        public void DeleteMaster(Master master)
        {
            masterRepository.Delete(master);
        }

        public void UpdateMaster(Master master)
        {
            masterRepository.Update(master);
        }

        public void SaveMaster()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Service
{
    public interface IMasterService
    {
        IEnumerable<Master> GetMasters();
        Master GetByID(long Id);







        void CreateMaster(Master master);
        void DeleteMaster(Master master);
        void UpdateMaster(Master master);
        void SaveMaster();
    }
}

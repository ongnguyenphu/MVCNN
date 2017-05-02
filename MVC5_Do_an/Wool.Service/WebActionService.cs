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
    public class WebActionService : IWebActionService
    {
        private readonly IWebActionRepository webActionRepository;
        private readonly IUnitOfWork unitOfWork;

        public WebActionService(IWebActionRepository webActionRepository, IUnitOfWork unitOfWork)
        {
            this.webActionRepository = webActionRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IWebActionService Members

        public IEnumerable<WebAction> GetWebActions()
        {
            return webActionRepository.GetAll();
        }

        public WebAction GetByID(long Id)
        {
            return webActionRepository.GetById(Id);
        }

        public void CreateWebAction(WebAction webAction)
        {
            webActionRepository.Add(webAction);
        }

        public void DeleteWebAction(WebAction webAction)
        {
            webActionRepository.Delete(webAction);
        }

        public void UpdateWebAction(WebAction webAction)
        {
            webActionRepository.Update(webAction);
        }

        public void SaveWebAction()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}

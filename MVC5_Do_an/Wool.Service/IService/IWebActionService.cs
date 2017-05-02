using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Model;

namespace Wool.Service
{
    public interface IWebActionService
    {
        IEnumerable<WebAction> GetWebActions();
        void CreateWebAction(WebAction webAction);
        void DeleteWebAction(WebAction webAction);
        void UpdateWebAction(WebAction webAction);
        WebAction GetByID(long Id);
        void SaveWebAction();
    }
}

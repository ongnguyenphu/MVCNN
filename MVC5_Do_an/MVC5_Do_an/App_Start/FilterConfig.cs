﻿using System.Web;
using System.Web.Mvc;

namespace MVC5_Do_an
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

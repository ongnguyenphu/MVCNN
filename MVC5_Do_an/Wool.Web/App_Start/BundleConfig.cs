using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Wool.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                    "~/cdn/Bootstrap/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                "~/Resources/CSS/bootstrap.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
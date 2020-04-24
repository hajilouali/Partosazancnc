using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Partosazancnc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/js").Include(
                "~/assets/plugins/jquery/jquery-2.1.4.min.js", "~/assets/js/scripts.js"));


            var cssfa = new StyleBundle(virtualPath: "~/css");
            cssfa.Include("~/assets/plugins/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform());
            cssfa.Include("~/assets/css/essentials.css", new CssRewriteUrlTransform());
            cssfa.Include("~/assets/css/layout.css", new CssRewriteUrlTransform());

            cssfa.Include("~/assets/plugins/bootstrap/RTL/bootstrap-rtl.min.css");
            cssfa.Include("~/assets/plugins/bootstrap/RTL/bootstrap-flipped.min.css");
            cssfa.Include("~/assets/css/layout-RTL.css");
            cssfa.Include("~/assets/css/header-1.css");
            cssfa.Include("~/assets/css/color_scheme/red.css");
            bundles.Add(cssfa);
        }
    }
}
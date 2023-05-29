using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Personel_MVC_SQL.App_Start
{
    public class bundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //sayfa ilk açıldığında yüklenen html css java script dosyalarını bir araya getirdik ki sayfa ilk açıldığında hızlı yüklensin
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-3.6.4.min.js", "~/Scripts/jquery.unobtrusive-ajax.min.js", "~/Scripts/bootstrap.min.js", "~/Scripts/DataTables/jquery.dataTables.min.js", "~/Scripts/DataTables/dataTables.bootstrap4.min.js", "~/Scripts/custom.js", "~/Scripts/bootbox.min.js"
                ));
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/bootstrap.min.css", "~/Content/site.css", "~/Content/DataTables/css/dataTables.jqueryui.min.css", "~/Content/DataTables/css/dataTables.bootstrap4.min.css", "~/Content/DataTables/css/dataTables.material.min.css"


                ));
        }
    }
}
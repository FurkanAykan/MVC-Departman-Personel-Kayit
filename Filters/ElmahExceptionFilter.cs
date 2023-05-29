using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personel_MVC_SQL.Filters
{
    public class ElmahExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
            }
        }
    }
}
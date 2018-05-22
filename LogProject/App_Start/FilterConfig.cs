using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogProject.App_Start
{
    public class FilterConfig
    {
        public static void Configure(GlobalFilterCollection filterCol)
        {
            filterCol.Add(new AuthorizeAttribute());
        }
    }
}
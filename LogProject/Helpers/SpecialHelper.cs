using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogProject.Helpers
{
    public class SpecialHelper: log4net.Util.PatternConverter
    {
            override protected void Convert(System.IO.TextWriter writer, object state)
            {
                string homePath = HttpRuntime.AppDomainAppPath;
                writer.Write(homePath);
            }
        }
    }

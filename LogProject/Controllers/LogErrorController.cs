using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;

[assembly: log4net.Config.XmlConfigurator(Watch =true)]
namespace LogProject.Controllers
{
    public class LogErrorController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // GET: LogError

        public ActionResult Log4Net()
        {
            log.Info("This is to log errors, proceed");
            int value = 790000000;
            try
            {
                // Square the original value.
                int square = value/0;
                Console.WriteLine("{0} ^ 2 = {1}", value, square);
            }
            catch (DivideByZeroException ex)
            {
                log.Fatal("This was a terrible error");
                log.Debug("Failed here too", ex);
            }
            return View();
        }

        public ActionResult NLog()
        {
            int value = 790000000;
            try
            {
                // Square the original value.
                int square = value / 0;
                Console.WriteLine("{0} ^ 2 = {1}", value, square);
            }
            catch (DivideByZeroException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, "Failed too");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Success()
        {
            return View();
        }
    }
}
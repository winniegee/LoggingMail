using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LogProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            var claimsPrincipal = this.User.Identity as ClaimsIdentity;
            var claims = claimsPrincipal.FindFirst("PassportUrl");
            // ViewBag.ProfileUrl = Claim.Value;
            ViewData["SalesAnalyticsCaptions"] = "Sales Analytics";
            return View();
        }
    }
}
using LogProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LogProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager<AppUser, Guid> manager;
        public AccountController()
        {
            manager = Startup.UserManagerFactory.Invoke();
        }

        // GET: Account
        [HttpPost]
        public ActionResult Signin(SigninDetails details)
        {
            if (this.ModelState.IsValid)
            {
                var signinDetails = manager.Find(details.Username, details.Password);
                if (details != null)
                {
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity("ApplicationCookie");
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, details.Username));
                    

                    var ctxt = this.Request.GetOwinContext();
                    ctxt.Authentication.SignIn(claimsIdentity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "UserName or Password is incorrect");
                }

            }
            return View(details);
        }

        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

    }
}
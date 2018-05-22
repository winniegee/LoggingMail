using LogProject.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LogProject.DataAccess
{
    public class AppDbContext :IdentityDbContext<AppUser, AppRole,Guid,AppUserLogin,AppUserRole,AppUserClaim>
    {
        public AppDbContext():base($"name={nameof(AppDbContext)}")
        {

        }
    }
}
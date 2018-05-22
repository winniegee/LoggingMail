namespace LogProject.Migrations
{
    using LogProject.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LogProject.DataAccess.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LogProject.DataAccess.AppDbContext context)
        {
            string username = "cyberacademy@gmail.com";
            string password = "admin";
            var userMgr = Startup.UserManagerFactory.Invoke();
            if (userMgr.FindByName(username) != null)
                return;
            var appUser = new AppUser()
            {
                UserName = username,

            };
            var result = userMgr.Create(appUser, password);


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

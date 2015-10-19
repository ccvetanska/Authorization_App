using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Authorization_App.Models;

namespace Authorization_App.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Authorization_App.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        // If you want to automatically add an user to da database
        protected override void Seed(Authorization_App.Models.ApplicationDbContext context)
        {
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser()
            {
                UserName = "adminUser@authorizationapp.com",
                Email = "adminUser@authorizationapp.com",
                EmailConfirmed = true
            };
           
            var IdUserResult = new IdentityResult();
            IdUserResult = userMgr.Create(appUser, "Sa1b2v3c4m!");

            // If the new "admin" user was successfully created, 
            // add the "admin" user to the "admin" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail("adminUser@authorizationapp.com").Id, "admin"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("adminUser@authorizationapp.com").Id, "admin");
            }

            context.Users.AddOrUpdate(
                        p => p.UserName,
                        appUser
                    );

        }
    }
}


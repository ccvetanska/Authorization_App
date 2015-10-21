using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Security;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Authorization_App.Logic;

namespace Authorization_App.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Authorization_App.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        // If you want to automatically add an user to da database
        protected override void Seed(Authorization_App.DataAccess.ApplicationDbContext context)
        {
            RoleActions roleActions = new RoleActions();
            roleActions.AddRole("admin");
            var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            //create a default admin user
            var appUser = new IdentityUser()
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


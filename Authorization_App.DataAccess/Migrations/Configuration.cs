using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authorization_App.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Authorization_App.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Authorization_App.DataAccess.ApplicationDbContext"; ContextKey = "Authorization_App.DataAccess.ApplicationDbContext";
        }

        // If you want to automatically add an user to da database
        protected override void Seed(Authorization_App.DataAccess.ApplicationDbContext context)
        {
            AddRole(context, "admin");
            var userMgr = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));

            //create a default admin user
            var appUser = new IdentityUser()
            {
                UserName = "adminUser@authorizationapp.com",
                Email = "adminUser@authorizationapp.com",
                EmailConfirmed = true
            };

            var IdUserResult = new IdentityResult();
            IdUserResult = userMgr.Create(appUser, "abcdef1");

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

        internal void AddRole(DataAccess.ApplicationDbContext context, string roleName)
        {
            IdentityResult IdRoleResult;
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists(roleName))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = roleName });
            }
        }
    }
}


namespace Authorization_App.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Authorization_App.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Authorization_App.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        //if you want to automatically add an user to da database
        //
        //protected override void Seed(Authorization_App.Models.ApplicationDbContext context)
        //{
        //    context.Users.AddOrUpdate(
        //                p => p.UserName,
        //                new ApplicationUser { UserName = "User Name"}
        //            );
        //}
    }
}

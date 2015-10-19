using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Authorization_App.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authorization_App.Logic
{
    internal class RoleActions
    {
        internal void AddRole(string roleName)
        {
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "roleName" role if it doesn't already exist.

            if (!roleMgr.RoleExists(roleName))
            {
                IdRoleResult= roleMgr.Create(new IdentityRole { Name = roleName });
            }

        }
    }
}
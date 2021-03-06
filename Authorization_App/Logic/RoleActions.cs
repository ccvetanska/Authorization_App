﻿using Authorization_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Authorization_App.DataAccess;

namespace Authorization_App.Logic
{
    internal class RoleActions
    {
        internal void AddRole(string roleName)
        {
            // Access the application context and create result variables.
            DataAccess.ApplicationDbContext context = new ApplicationDbContext();
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
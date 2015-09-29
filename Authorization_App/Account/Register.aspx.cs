using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Authorization_App.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authorization_App.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                string code = manager.GenerateEmailConfirmationToken(user.Id);
                string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                if (user.EmailConfirmed)
                {
                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = "An email has been sent to your account. Please view the email and confirm your account to complete the registration process.";
                }
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void IsAdmin_CheckedChanged(object sender, EventArgs e)
        {
            {
                // Access the application context and create result variables.
                Models.ApplicationDbContext context = new ApplicationDbContext();
                IdentityResult IdRoleResult;
                IdentityResult IdUserResult;

                // Create a RoleStore object by using the ApplicationDbContext object. 
                // The RoleStore is only allowed to contain IdentityRole objects.
                var roleStore = new RoleStore<IdentityRole>(context);

                // Create a RoleManager object that is only allowed to contain IdentityRole objects.
                // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
                var roleMgr = new RoleManager<IdentityRole>(roleStore);

                // Then, you create the "admin" role if it doesn't already exist.
                if (!roleMgr.RoleExists("admin"))
                {
                    IdRoleResult = roleMgr.Create(new IdentityRole { Name = "admin" });
                }

                // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
                // object. Note that you can create new objects and use them as parameters in
                // a single line of code, rather than using multiple lines of code, as you did
                // for the RoleManager object.
                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var appUser = new ApplicationUser
                {
                    UserName = Email.Text,
                    Email = Email.Text
                };

                IdUserResult = userMgr.Create(appUser, Password.Text);
                
                // If the new "adminUser" user was successfully created, 
                // add the "adminUser" user to the "admin" role. 
                if (!userMgr.IsInRole(userMgr.FindByEmail(Email.Text).Id, "admin"))
                {
                    IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(Email.Text).Id, "admin");
                }
            }
        }
    }
}
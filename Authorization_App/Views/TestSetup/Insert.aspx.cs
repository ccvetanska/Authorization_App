using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Authorization_App.Model;
using Authorization_App.DataAccess;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Authorization_App.Views.TestSetup
{
    public partial class Insert : System.Web.UI.Page
    {
		protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // This is the Insert method to insert the entered TestSetup item
        // USAGE: <asp:FormView InsertMethod="InsertItem">
        public void InsertItem()
        {
            using (_db)
            {
                var item = new Authorization_App.Model.TestSetup();

                //The default Expire Date of the TestSetup is set to a day from the Creation Date
                item.ExpiresAt = DateTime.Now.AddDays(1);

                //We use System.Guid to generate a random string. The parameter "N" is used to set the format.
                //It means 32 digits without hyphens and braces.
                string rand32digString = System.Guid.NewGuid().ToString("N");

                //We will need only the first 8 digits of this string.
                item.Code = rand32digString.Substring(0,8);

                string userId = HttpContext.Current.User.Identity.GetUserId();
                item.AuthorId = userId;

                TryUpdateModel(item);


                if (ModelState.IsValid)
                {
                    // Save changes
                    _db.TestSetup.Add(item);
                    _db.SaveChanges();

                    Response.Redirect("Default");
                }
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("Default");
            }
        }
    }
}

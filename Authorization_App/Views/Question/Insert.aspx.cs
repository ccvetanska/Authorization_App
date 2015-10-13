using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Authorization_App.Models;


namespace Authorization_App.Views.Question
{
    public partial class Insert : System.Web.UI.Page
    {
		protected Authorization_App.Models.ApplicationDbContext _db = new Authorization_App.Models.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // This is the Insert method to insert the entered Question item
        // USAGE: <asp:FormView InsertMethod="InsertItem">
        public void InsertItem()
        {
            using (_db)
            {
                var item = new Authorization_App.Models.Question();

                TryUpdateModel(item);

                string userId = HttpContext.Current.User.Identity.GetUserId();
                item.AuthorId = userId;

                if (ModelState.IsValid)
                {
                    // Save changes
                    _db.Question.Add(item);
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
            if (e.CommandName.Equals("Add_Option", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/Views/QuestionOption/Default");
            }
        }
    }
}

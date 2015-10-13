using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Authorization_App.Models;

namespace Authorization_App.Views.QuestionOption
{
    public partial class Insert : System.Web.UI.Page
    {
        protected Authorization_App.Models.ApplicationDbContext _db = new Authorization_App.Models.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // This is the Insert method to insert the entered QuestionOption item
        // USAGE: <asp:FormView InsertMethod="InsertItem">
        public void InsertItem()
        {
            using (_db)
            {
                var item = new Authorization_App.Models.QuestionOption();

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes
                    _db.QuestionOption.Add(item);
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

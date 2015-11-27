using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Authorization_App.Model;
using Authorization_App.BusinessServices;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Authorization_App.Views.TestSetup
{
    public partial class Insert : System.Web.UI.Page
    {
		protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["expDate"] = DateTime.Now.AddDays(1);
                var ExpiresAtClndr = formviewID.FindControl("ExpiresAtClndr") as Calendar;
                ExpiresAtClndr.SelectionChanged += new EventHandler(this.ExpiresAtClndr_SelectionChanged);
                var testDropdown = formviewID.FindControl("testDrpdwn") as DropDownList;

                //populate dropdown list here

                TestService testService = new TestService(_db);

                var testQuery = testService.GetAll();
                List<string> testList = new List<string>();
                foreach (Model.Test t in testQuery)
                {
                    testList.Add(t.Name);
                }

                testDropdown.DataSource = testList;
                testDropdown.DataBind();
            }
                          
        }


        // This is the Insert method to insert the entered TestSetup item
        // USAGE: <asp:FormView InsertMethod="InsertItem">
        public void InsertItem()
        {
            using (_db)
            {
                var testDropdown = formviewID.FindControl("testDrpdwn") as DropDownList;
                var item = new Authorization_App.Model.TestSetup();


                if (ViewState["expDate"]!=null)
                {
                    item.ExpiresAt = (DateTime)ViewState["expDate"];
                }                

                //We use System.Guid to generate a random string. The parameter "N" is used to set the format.
                //It means 32 digits without hyphens and braces.
                string rand32digString = System.Guid.NewGuid().ToString("N");

                //We will need only the first 8 digits of this string.
                item.Code = rand32digString.Substring(0,8);

                string userId = HttpContext.Current.User.Identity.GetUserId();
                item.AuthorId = userId;


                var selectedTest = testDropdown.SelectedItem;
                TestService testService = new TestService(_db);
                
                Model.Test t =testService.Find(selectedTest.Text);

                if(t!=null)
                {
                    item.TestId = t.Id;
                }
                

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


        protected void ExpiresAtClndr_SelectionChanged(object sender, EventArgs e)
        {
            Calendar cl = sender as Calendar;
            if (cl.SelectedDate != null)
            {
                ViewState["expDate"] = cl.SelectedDate;
            }
            else
            {
                ViewState["expDate"] = DateTime.Now.AddDays(1);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Authorization_App.Model;
using Authorization_App.BusinessServices;

namespace Authorization_App
{
    public partial class Start : System.Web.UI.Page
    {
        protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            // Click the button --> search for TestSetup with the same code as the code in the TextField --> if yes 
            // open the test with the same ID as the TestId field of TestSetup. If no, redirect to error page.

            string code = CodeTextBox.Text;
            TestService testService = new TestService(_db);
            Test ts=testService.FindTestByCode(code);  
            if (ts!= null)
            {
                Response.Redirect("../Default");
            }
            else
            {
                wrongCodeLabel.Visible = true;
            }

        }


    }
}
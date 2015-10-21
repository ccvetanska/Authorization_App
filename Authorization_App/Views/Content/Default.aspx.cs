using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace Authorization_App.Views.Content
{
    public partial class Default : System.Web.UI.Page
    {
        protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of Content entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<Authorization_App.Model.Content> GetData()
        {
            return _db.Content;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Authorization_App.Model;
using Authorization_App.DataAccess;
using Microsoft.Owin.Security.OAuth;

namespace Authorization_App.Views.Test
{
    public partial class Default : System.Web.UI.Page
    {
		protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.IsPostBack) return;

            //var questions = (from n in _db.Question
            //             select n).OrderBy(n => n.Title);

            //qListView = questions;
            //qListView.DataBind();
        }

        // Model binding method to get List of Test entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<Authorization_App.Model.Test> GetData()
        {
            return _db.Test;
        }
    }
}


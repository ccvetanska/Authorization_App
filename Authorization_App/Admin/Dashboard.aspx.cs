using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Authorization_App.DataAccess;
using Authorization_App.DataAccess.Repositories;
using Authorization_App.DataAccess.Interfaces;
using Authorization_App.Model;

namespace Authorization_App.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
//test the MongoDB

            IRepository<Test> testRepo = new MongoRepository<Test>();

            var t = new Test();
            t.Name = "testMNG";
            testRepo.Insert(t);

        }
    }
}
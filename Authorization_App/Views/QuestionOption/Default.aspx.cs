using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Authorization_App.Model;
using Authorization_App.DataAccess;
using Authorization_App.BusinessServices;

namespace Authorization_App.Views.QuestionOption
{
    public partial class Default : System.Web.UI.Page
    {
		protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Model binding method to get List of QuestionOption entries
        // USAGE: <asp:ListView SelectMethod="GetData">
        public IQueryable<Authorization_App.Model.QuestionOption> GetData()
        {
            int questionId = (int) Session["questionId"];
            QuestionService questionService = new QuestionService(_db);
            return questionService.GetOptionsForQuestion(questionId);

            //return _db.QuestionOption.Include(m => m.Question);
        }
    }
}


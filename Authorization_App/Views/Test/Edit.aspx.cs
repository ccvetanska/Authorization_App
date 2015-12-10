using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Windows.Controls.Primitives;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Authorization_App.Model;
using Authorization_App.DataAccess;
using Authorization_App.BusinessServices;
using Microsoft.AspNet.FriendlyUrls;


namespace Authorization_App.Views.Test
{
    public partial class Edit : System.Web.UI.Page
    {
        protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();
        protected Authorization_App.DataAccess.ApplicationDbContext Question_db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // Add Question items

        public IQueryable<Authorization_App.Model.Question> GetData()
        {
            return Question_db.Question.SortBy("Title");
        }

        // This is the Update method to update the selected Test item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(int id)
        {
            using (_db)
            {
                var item = _db.Test.Find(id);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                    return;
                }

                TryUpdateModel(item);

                if (ModelState.IsValid)
                {
                    // Save changes here
                    _db.SaveChanges();
                    Response.Redirect("../Default");
                }
            }

            //TestService testService = new TestService(_db);
            //List<int> checkBoxIds = ViewState["checkBoxIds"] as List<int>;
            //if (checkBoxIds != null)
            //{
            //    foreach (int questionId in checkBoxIds)
            //    {
            //        testService.AddQuestionToTest(questionId, id, _db);
            //    }
            //    System.Windows.Forms.MessageBox.Show("Questions successfuly added!");
            //}
            //else
            //{
            //    System.Windows.Forms.MessageBox.Show("You did not make any changes to the questions.");
            //}
            //Response.Redirect("../Default");
        }

        // This is the Select method to selects a single Test item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public Authorization_App.Model.Test GetItem([FriendlyUrlSegmentsAttribute(0)]int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.Test.Find(Id);
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
            //if (e.CommandName.Equals("Add", StringComparison.OrdinalIgnoreCase))
            //{
            //    Response.Redirect("~/Views/Test/Default");
            //}
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            IList<string> segments = null;
            int itemId=0;

            if (Request != null)
            {
                segments = Request.GetFriendlyUrlSegments();
                Int32.TryParse(segments[0], out itemId);
            }
                        
            TestService testService = new TestService(_db);            
            List<int> checkBoxIds = ViewState["checkBoxIds"] as List<int>;
            if (checkBoxIds != null)
            {
                foreach (int questionId in checkBoxIds)
                {
                    testService.AddQuestionToTest(questionId, itemId, _db);
                }

                StatusLabel.Text = "Questions successfuly added!";               
            }
            else
            {
                StatusLabel.Text= "You did not make any changes to the questions.";
            }
                       
        }
                
        protected void QuestionCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            HiddenField hf = null;
            foreach (Control c in cb.Parent.Controls)
            {
                if (c is HiddenField)
                {
                    hf = c as HiddenField;
                }
            }
            int id;
            List<int> checkBoxIds = new List<int>();

            if (!Int32.TryParse(hf.Value, out id))
            {
                throw new InvalidCastException();
            }

            TestService testService = new TestService(_db);

            foreach (string key in ViewState.Keys)
            {
                if (key == "checkBoxIds")
                {
                    checkBoxIds = ViewState["checkBoxIds"] as List<int>;
                    testService.manageList(checkBoxIds, cb.Checked, id);
                    ViewState["checkBoxIds"] = checkBoxIds;
                }
            }
            testService.manageList(checkBoxIds, cb.Checked, id);
            ViewState["checkBoxIds"] = checkBoxIds;
        }

        public bool isAdded(string questionId)
        {
            Authorization_App.DataAccess.ApplicationDbContext _dbCtx = new Authorization_App.DataAccess.ApplicationDbContext();
            using (_dbCtx)
            {
                int qId = 0;
                Int32.TryParse(questionId, out qId);
                IList<string> segments = null;
                int testId = 0;

                if (Request != null)
                {
                    segments = Request.GetFriendlyUrlSegments();
                    Int32.TryParse(segments[0], out testId);
                }
                QuestionService questionService = new QuestionService(_dbCtx);
                bool res = questionService.isAdded(qId, testId);
                _dbCtx.Dispose();
                return res;
            }
        } 
        
    }

}


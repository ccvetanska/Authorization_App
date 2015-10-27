using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using Authorization_App.Model;
using Authorization_App.DataAccess;
using Authorization_App.BusinessServices;

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
            return Question_db.Question;
        }

        // This is the Update methd to update the selected Test item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(int Id)
        {
            using (_db)
            {
                var item = _db.Test.Find(Id);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
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
            if (e.CommandName.Equals("Add", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("~/Views/Question/Default");
            }
        }

        protected void Question_Add(object sender, EventArgs e)
        {
            //if (QuestionCheckbox.Checked == true)
            //{
            //}
        }

        //protected void isAdded_CheckedChanged(object sender, EventArgs e)
        //{
        //    QuestionService questionService = new QuestionService(_db);
        //    CheckBox cb = sender as CheckBox;
        //    HiddenField hf = null;
        //    //cb.Parent.Controls is the collection of the cb's brothers in the tree.
        //    foreach (Control c in cb.Parent.Controls)
        //    {

        //        if (c is HiddenField)
        //        {
        //            hf = c as HiddenField;
        //        }

        //    }
        //    if (cb != null && hf != null)
        //    {
        //        int id;
        //        if (Int32.TryParse(hf.Value, out id))
        //        {
        //            questionService.ChangeCompleted(id, cb.Checked);
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Cannot cast string to int!");
        //        }
        //    }
        //    RebindItems(_view.ShowCompleted.Checked);
        //}


    }
}

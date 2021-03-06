﻿using System;
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
namespace Authorization_App.Views.Question
{
    public partial class Edit : System.Web.UI.Page
    {
		protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // This is the Update methd to update the selected Question item
        // USAGE: <asp:FormView UpdateMethod="UpdateItem">
        public void UpdateItem(int  Id)
        {
            using (_db)
            {
                var item = _db.Question.Find(Id);

                if (item == null)
                {
                    // The item wasn't found
                    ModelState.AddModelError("", String.Format("Item with id {0} was not found", Id));
                    return;
                }

                TryUpdateModel(item);

                item.UpdatedAt = DateTime.Now;

                if (ModelState.IsValid)
                {
                    // Save changes here
                    _db.SaveChanges();
                    Response.Redirect("../Default");
                }
            }
        }

        // This is the Select method to selects a single Question item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public Authorization_App.Model.Question GetItem([FriendlyUrlSegmentsAttribute(0)]int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.Question.Find(Id);
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }

            //if (e.CommandName.Equals("Add_Option", StringComparison.OrdinalIgnoreCase))
            //{


            //}
        }

        protected void AddOptionButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            int questionId;
            Int32.TryParse(btn.CommandArgument, out questionId);
            Session["questionId"] = questionId;
            Response.Redirect("~/Views/QuestionOption/Default");
        }
    }
}

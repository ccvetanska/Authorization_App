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
using Authorization_App.BusinessServices;

namespace Authorization_App.Views.Question
{
    public partial class Delete : System.Web.UI.Page
    {
		protected Authorization_App.DataAccess.ApplicationDbContext _db = new Authorization_App.DataAccess.ApplicationDbContext();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // This is the Delete methd to delete the selected Question item
        // USAGE: <asp:FormView DeleteMethod="DeleteItem">
        public void DeleteItem(int Id)
        {
            //using (_db)
            //{
            //    var item = _db.Question.Find(Id);

            //    if (item != null)
            //    {
            //        _db.Question.Remove(item);
            //        _db.SaveChanges();
            //    }
            //}
            QuestionService questionService = new QuestionService(_db);
            questionService.Delete(Id);

            Response.Redirect("../Default");
        }

        // This is the Select methd to selects a single Question item with the id
        // USAGE: <asp:FormView SelectMethod="GetItem">
        public Authorization_App.Model.Question GetItem([FriendlyUrlSegmentsAttribute(0)]int? Id)
        {
            if (Id == null)
            {
                return null;
            }

            using (_db)
            {
	            return _db.Question.Where(m => m.Id == Id).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Default");
            }
        }
    }
}


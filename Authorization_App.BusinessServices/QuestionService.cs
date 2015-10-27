using Authorization_App;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Authorization_App.Model;
using Authorization_App.DataAccess;

namespace Authorization_App.BusinessServices
{
    public class QuestionService
    {
        public QuestionService(DbContext dbCtx)
        {
            QuestionManager = new EntityManager<Question>(dbCtx);
            ContentManager = new EntityManager<Content>(dbCtx);
            QuestionOptionManager = new EntityManager<QuestionOption>(dbCtx);
        }

        public EntityManager<Question> QuestionManager { get; set; }

        public EntityManager<QuestionOption> QuestionOptionManager { get; set; }

        public EntityManager<Content> ContentManager { get; set; }
       
        public Question Add(Question q)
        {
            Question res = QuestionManager.Add(q);
            return res;
        }
    }
}
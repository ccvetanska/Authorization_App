using Authorization_App;
using Authorization_App.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authorization_App.Services
{
    public class QuestionService
    {
        public QuestionService(DbContext dbCtx)
        {
            QuestionManager = new EntityManager<Question>(dbCtx);
            ContentManager = new EntityManager<Content>(dbCtx);
        }

        public EntityManager<Question> QuestionManager { get; set; }

        public EntityManager<Content> ContentManager { get; set; }

        public Question Add(Question q)
        {
            Question res = QuestionManager.Add(q);
            return res;
        }
    }
}
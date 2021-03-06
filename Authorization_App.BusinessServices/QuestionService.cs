﻿using Authorization_App;
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
        
        public string GetQuestionText(int id)
        {
            Question q = QuestionManager.Find(id);
            if (q!= null)
            {
                return q.Description;
            }
            return null;
        }

        public Question Find(int id)
        {
            Question res = QuestionManager.Find(id);
            return res;
        }

        public bool Delete(int id)
        {
            Question q = QuestionManager.Find(id);

            if (q != null && q.QuestionOption != null)
            {
                foreach (QuestionOption qo in q.QuestionOption)
                {
                    QuestionOptionManager.Delete(qo.Id);
                }
            }
            return QuestionManager.Delete(id);
        }

        public bool isAdded(int qId, int tId)
        {
            Question q = QuestionManager.Find(qId);
            ICollection<Test> questionTests = q.TestsList;

            return questionTests.Any(test => test.Id == tId);
        }

        public string GetQuestionType(Question question)
        {
            var qType = question.QuestionType;
            return qType.ToString();
        }

        public void AddOptionToQuestion(int questionId, QuestionOption qOption)
        {
            Question question = QuestionManager.Find(questionId);
            if (question!=null && qOption!=null)
            {
                question.QuestionOption.Add(qOption);
            }            
        }

        public IQueryable<QuestionOption> GetOptionsForQuestion(int questionId)
        {
            Question question = QuestionManager.Find(questionId);

            return QuestionOptionManager.Query().Where(qo => qo.Question.Id == question.Id);
        }
    }
}
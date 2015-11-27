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
    public class TestService
    {
        public TestService(DbContext dbCtx)
        {
            TestManager = new EntityManager<Test>(dbCtx); 
            TestSetupManager = new EntityManager<TestSetup>(dbCtx);
        }

        public EntityManager<Test> TestManager { get; set; }

        public EntityManager<TestSetup> TestSetupManager { get; set; }


        /// <summary>
        /// Finds the Test associated with the code.
        /// </summary>
        /// <param name="code">key for the search</param>
        /// <returns>the Test item or returns null if no item is found</returns>
        public Test FindTestByCode(string code)
        {            
            var tsQuery = TestSetupManager.Query();

            foreach (TestSetup ts in tsQuery)
            {
                Test test=null;
                if (ts.Code == code)
                {
                    test = TestManager.Find(ts.TestId);
                    if(test!=null && test.isActive==true)
                        return test;
                }
            }
                           
            return null;
        }

        public Test Find(int id)
        {
            Test res = TestManager.Find(id);
            return res;
        }

        public Test Find(string name)
        {
            var tsQuery = TestManager.Query();
            foreach (Test t in tsQuery)
            {
                if (t.Name == name)
                    return t;               
            }
            return null;
        }

        /// <summary>
        /// Adds or removes element from list. If operation is true, adds it. Removes it otherwise.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="operation"></param>
        /// <param name="element"></param>
        public void manageList(List<int> list, bool operation, int element)
        {
            if (operation)
            {
                list.Add(element);
            }
            else
            {
                list.Remove(element);
            }

        }

        public IQueryable<Test> GetAll()
        {
            return TestManager.Query();

        }

        public void AddQuestionToTest(int questionId, int testId, DbContext dbCtx)
        {
            QuestionService qservice= new QuestionService(dbCtx);
            TestService tservice = new TestService(dbCtx);

            Question q = qservice.Find(questionId);
            Test t = tservice.Find(testId);

            t.Questions.Add(q);
            q.TestsList.Add(t);
                        
            qservice.QuestionManager.Update(q);
            tservice.TestManager.Update(t);
        }

        public Question FindQuestionInTestByIndex(int testId, int questionIndex)
        {
            Test test = TestManager.Find(testId);
            if (test!=null && (questionIndex < test.Questions.Count))
            {
                return test.Questions.ElementAt(questionIndex);
            }
            return null;
        }

        public bool IsLastQuestionInTest(Question q, Test ts)
        {
            return ts.Questions.Last().Id == q.Id;
        }
               
    }
}

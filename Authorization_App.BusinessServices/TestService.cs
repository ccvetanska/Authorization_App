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
                if (ts.Code == code)
                {
                    return TestManager.Find(ts.TestId);
                }
            }
                           
            return null;
        }

    }
}

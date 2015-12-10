using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authorization_App.DataAccess;
using Authorization_App.DataAccess.Repositories;
using Authorization_App.DataAccess.Interfaces;
using Authorization_App.Model;
using MongoDB.Bson;

namespace Authorization_App.BusinessServices
{
    public class TestReportService
    {

        IRepository<TestReport> TestReportRepository;

        public TestReportService()
        {
            TestReportRepository = new MongoRepository<TestReport>();
        }

        public void Add(TestReport tr)
        {
            TestReportRepository.Insert(tr);
        }

        public void Delete(int id)
        {
            TestReportRepository.Delete(id);
        }

        public TestReport Find(int id)
        {
            return TestReportRepository.GetOne(x => x.Id == id).Result;
        }
        
        public void AddAnswer(int TestReportId, string answer)
        {
            var test = TestReportRepository.GetOne(t => t.Id == TestReportId).Result;
            
            if (test!=null)
            {
                test.Answers.Add(answer);
                TestReportRepository.Update(t => t.Id == TestReportId, test);
            }
        }

        public async void Update(TestReport testReport)
        {
            if (testReport != null)
            {
                var existingReport = await TestReportRepository.GetOne(t => t.Id == testReport.Id);

                if (existingReport == null)
                {
                    return;
                }
                 testReport._id = existingReport._id;

                TestReportRepository.Update(t => t.Id == testReport.Id, testReport);
            }
        }
    }
}

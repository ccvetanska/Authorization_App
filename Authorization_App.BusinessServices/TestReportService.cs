using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authorization_App.DataAccess;
using Authorization_App.DataAccess.Repositories;
using Authorization_App.DataAccess.Interfaces;
using Authorization_App.Model;

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

        
        // No Update?? 
    }
}

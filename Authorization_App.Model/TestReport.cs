using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization_App.Model
{
    public class TestReport
    {
        public int TestId { get; set; }

        public string AuthorId { get; set; }

        public string Code { get; set; }

        public TimeSpan Time()
        {
            return new TimeSpan();
        }

        public DateTime ExpiresAt { get; set; }

        public string Candidate { get; set; }

        public string Position { get; set; }

    }
}

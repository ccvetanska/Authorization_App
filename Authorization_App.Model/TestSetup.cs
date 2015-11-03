using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization_App.Model
{
    public class TestSetup: IEntity
    {
        [Key]
        public int Id { get; set; }

        public TestSetup()
        {
        }

        //The id of the Test associated with the TestSetup
        public int TestId { get; set; }

        public string AuthorId { get; set; }

        [StringLength(8)]
        [Index("UQ_TestSetup_Code", 1, IsUnique=true)]
        public string Code { get; set; }

        public TimeSpan Time()
        {
            return new TimeSpan();
        }

        public DateTime ExpiresAt { get; set; }
    }
}

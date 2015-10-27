using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Authorization_App.Model
{
    public class TestSetup: IEntity
    {
        [Key]
        public int Id { get; set; }

        public TestSetup()
        {
            //The default Expire Date of the TestSetup is set to a day from the Creation Date
            ExpiresAt = DateTime.Now.AddDays(1);

            //We use System.Guid to generate a random string. The parameter "N" is used to set the format.
            //It means 32 digits without hyphens and braces.
            string rand32digString = System.Guid.NewGuid().ToString("N");

            //We will need only the first 8 digits of this string.
            this.Code = rand32digString.Take(8).ToString();
        }

        //The id of the Test associated with the TestSetup
        public int TestId { get; set; }

        public string AuthorId { get; set; }

        [StringLength(8)]
        public string Code { get; set; }

        public TimeSpan Time()
        {
            return new TimeSpan();
        }

        public DateTime ExpiresAt { get; set; }
    }
}

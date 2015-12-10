using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authorization_App.Model
{
    [Serializable]
    public class Test : IEntity
    {      
        [Key]
        public int Id { get; set; }

        [StringLength(512)]
        public string Name { get; set; }

        //The Author is IdentityUser
        public string AuthorId { get; set; }

        public bool isActive { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}

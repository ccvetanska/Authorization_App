using System;
using System.Web;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using Authorization_App.Model;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authorization_App.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
            : base("Authorization_App", throwIfV1Schema: false)
        {
        }

        // create the table for the Questions
        public DbSet<Question> Question { get; set; }

        // create the table for the Content
        public DbSet<Content> Content { get; set; }

        // create the table for the QuestionOption
        public DbSet<QuestionOption> QuestionOption { get; set; }

        // create the table for the Test
        public DbSet<Test> Test { get; set; }

        public DbSet<TestSetup> TestSetup { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }  
}
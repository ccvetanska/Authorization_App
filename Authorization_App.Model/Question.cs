using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Authorization_App.Nomenclatures;

namespace Authorization_App.Model
{
    // (initial domain class) model class for the table Questions
    // Question may include many QuestionOptions
    public class Question : IEntity
    {
        public Question()
        {
            CreatedAt = DateTime.Now;
            var QuestionsList = new List<QuestionOption>();
        }

        [Key]
        public int Id { get; set; }

        // The user'ID who created the record
        public string AuthorId { get; set; }

        public QuestionTypes.QuestionType QuestionType { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [StringLength(1028)]
        public string Tags { get; set; }

        public int Level { get; set; }

        public TimeSpan Time()
        {
            return new TimeSpan();
        }
        // the date when the question is created
        public DateTime CreatedAt { get; set; }

        // The date when the question is updated
        public DateTime? UpdatedAt { get; set; }

        public Content Content { get; set; }

        public virtual ICollection<QuestionOption> QuestionOption { get; set; }

        public virtual ICollection<Test> TestsList { get; set; }

    }
}
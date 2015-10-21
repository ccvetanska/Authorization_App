using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization_App.Model
{
    // model class for the table QuestionsOptions
    public class QuestionOption : IEntity
    {
        public QuestionOption() { }
        [Key]
        public int Id { get; set; }

        public Content Content { get; set; }

        public bool isCorrect { get; set; }

        public int QuestionRefId { get; set; }

        // ForeignKey is used to link two tables together (referencing key)
        // The relationship between 2 tables matches the Primary Key in one of the tables with a Foreign Key in the second table.
        [ForeignKey("QuestionRefId")]
        public virtual Question Question { get; set; }
    }
}
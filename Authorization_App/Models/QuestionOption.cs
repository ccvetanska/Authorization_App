using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authorization_App.Models
{
    public class QuestionOption
    {
        public int Id { get; set; }

        public QuestionOption() { }

        public Content Content { get; set; }

        public bool isCorrect { get; set; }

        public int QuestionRefId { get; set; }

        [ForeignKey("QuestionRefId")]
        public virtual Question Question { get; set; }

    }
}
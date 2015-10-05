using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace Authorization_App.Models
{
    // model class for the database Questions
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public enum Type
        {
            Single,
            Multiple,
            Code,
            Text
        }
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
    }
}
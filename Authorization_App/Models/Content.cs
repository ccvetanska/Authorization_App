using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Authorization_App.Models
{
    // model class for the table Content
    public class Content
    {
        [Key]
        public int Id { get; set; }

        public enum Type
        {
            Text,
            Code,
            Video,
            Audio
        }

        [MaxLength(1028)]
        public string Body { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Authorization_App.Nomenclatures;
using Authorization_App.DataAccess;


namespace Authorization_App.Model
{
    // model class for the table Content
    public class Content : IEntity
    {
        [Key]
        public int Id { get; set; }

        public ContentTypes.ContentType ContentType { get; set; }

        [MaxLength(1028)]
        public string Body { get; set; }
    }
}
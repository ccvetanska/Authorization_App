using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_App.Nomenclatures
{
    public class QuestionTypes
    {
        public enum QuestionType
        {
            Single,                 //radiobuttons
            Multiple,               //checkboxes
            Code,                   //code field
            Text                    //textfield
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_App.BusinessRules
{
    public class TextQuestionTypeAction : IRuleAction
    {
        public bool IsValidated(string input)
        {
            return "Text".Equals(input);
        }

        public Action Action
        {
            get;
            set;
        }
    }
}
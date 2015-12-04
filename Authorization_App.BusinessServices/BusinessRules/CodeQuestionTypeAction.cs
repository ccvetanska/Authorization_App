using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_App.BusinessRules
{
    public class CodeQuestionTypeAction : IRuleAction
    {
        public bool IsValidated(string input)
        {
            return "Code".Equals(input);
        }

        public Action Action
        {
            get;
            set;
        }
    }
}
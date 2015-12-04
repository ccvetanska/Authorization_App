using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_App.BusinessRules
{
    public class MultipleQuestionTypeAction : IRuleAction
    {
        public bool IsValidated(string input)
        {
            return "Multiple".Equals(input);
        }

        public Action Action
        {
            get;
            set;
        }
    }
}
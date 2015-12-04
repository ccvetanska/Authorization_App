using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authorization_App.BusinessRules
{
    public interface IRuleAction
    {
        bool IsValidated(string input);

        Action Action { get; set; }
    }
}
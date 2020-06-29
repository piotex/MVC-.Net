using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DotNet_v2.Helpers
{
    public static class InputValidationHelpers
    {
        public static bool IsValid(this string value)
        {
            bool ok = true;
            if (value=="" || value.Contains('-'))
            {
                ok = false;
            }
            return ok;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DotNet.Hellpers
{
    public static class String_Hellper
    {
        public static bool IsValid(this string data)
        {
            if (!data.Contains("--"))
            {
                return true;
            }
            return false;
        }
    }
}

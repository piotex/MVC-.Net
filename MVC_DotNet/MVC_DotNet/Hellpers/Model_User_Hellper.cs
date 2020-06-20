using MVC_DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DotNet.Hellpers
{
    public static class Model_User_Hellper
    {
        public static bool IsValid(this Model_User user)
        {
            var properties = user.GetType().GetProperties();
            foreach (var propertie in properties)
            {
                if (null != propertie.GetValue(user) && !propertie.GetValue(user).ToString().IsValid())
                {
                    return false;
                }
            }
            return true;
        }
    }
}

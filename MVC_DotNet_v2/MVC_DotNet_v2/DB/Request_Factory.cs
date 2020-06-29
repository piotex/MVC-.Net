﻿using LionLibrary.Classes.Models;
using LionLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MVC_DotNet_v2.DB
{
    public class Request_Factory<T_Result> : Factory_Request<T_Result> where T_Result : Model_Table, new()
    {
        protected override string Get_PathTo_ConnectionStr()
        {
            //return @"C:\Users\pkubo\OneDrive\Desktop\MVC_DotNet\MVC_DotNet_v2\LionLibrary\db_config.xml";
            return ConfigurationManager.ConnectionStrings["ConnectionStrings"].ConnectionString;
        }
    }
}
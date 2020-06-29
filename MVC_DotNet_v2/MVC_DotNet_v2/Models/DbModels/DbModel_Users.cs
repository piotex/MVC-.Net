using LionLibrary.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DotNet_v2.Models.DbModels
{
    public class DbModel_Users : Model_Table
    {
        public int id { get; set; }
        public int role_id { get; set; }
        public string name { get; set; }
        public string pwd { get; set; }
        public string email { get; set; }

        public override string GetTableName()
        {
            return "users";
        }
    }
}
using LionLibrary.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DotNet_v2.Models.DbModels
{
    public class DbModelJoin_Products : Model_Table
    {
        public int id { get; set; }
        public int _quantity_ { get; set; }
        public int _type_ { get; set; }
        public string categorie_name { get; set; }
        public string _name_ { get; set; }
        public double _price_ { get; set; }

        public override string GetTableName()
        {
            return "xxx";
        }
    }
}
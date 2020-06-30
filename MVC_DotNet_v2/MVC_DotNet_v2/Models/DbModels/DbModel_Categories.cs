﻿using LionLibrary.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DotNet_v2.Models.DbModels
{
    public class DbModel_Categories : Model_Table
    {
        public int id { get; set; }
        public string categorie_name { get; set; }
        public int categorie_id { get; set; }

        public override string GetTableName()
        {
            return "categories";
        }
    }
}

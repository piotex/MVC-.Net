﻿using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Table
{
    public class Model_UserTable : Model_Table<Model_User>
    {
        public Model_UserTable()
        {
            Query = "SELECT * FROM users";
            Rows = new List<Model_User>();
            ColumnsNames = new List<string> { "id", "name", "pwd", "email" };
        }
    }
}

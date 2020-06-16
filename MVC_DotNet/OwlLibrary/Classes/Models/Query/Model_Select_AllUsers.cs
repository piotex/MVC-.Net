﻿using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query
{
    public class Model_Select_AllUsers : Model_Query<Model_User>
    {
        public Model_Select_AllUsers()
        {
            Rows = new List<Model_User>();
        }
        public override string get_Query()
        {
            return "SELECT * FROM users";
        }
    }
}

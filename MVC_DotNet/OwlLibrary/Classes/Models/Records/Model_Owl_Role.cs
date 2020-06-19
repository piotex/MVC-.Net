using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Records
{
    public class Model_Owl_Role : Model_TableRecord
    {
        public Model_Owl_Role()
        {
            table_name = "user_role";
        }
        public int role_id { get; set; }
        public string role_name { get; set; }

    }
}

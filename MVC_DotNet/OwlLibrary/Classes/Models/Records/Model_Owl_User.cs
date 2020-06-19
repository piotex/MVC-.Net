using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Records
{
    public class Model_Owl_User : Model_TableRecord
    {
        public Model_Owl_User()
        {
            id = 0;
            table_name = "users";
        }
        public int role_id { get; set; }
        public string name { get; set; }
        public string pwd { get; set; }
        public string email { get; set; }

    }
}

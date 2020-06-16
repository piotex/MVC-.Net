using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Table
{
    public class Model_User_Role : Model_Table<Model_Role>
    {
        public Model_User_Role()
        {
            Query = "SELECT * FROM user_role; ";
            Rows = new List<Model_Role>();
            //ColumnsNames = new List<string> { "id", "role_id", "role_name" };
        }
        public Model_User_Role(string where_constrain)
        {
            Query = "SELECT * FROM user_role where "+ where_constrain;
            Rows = new List<Model_Role>();
            //ColumnsNames = new List<string> { "id", "role_id", "role_name" };
        }
    }
}

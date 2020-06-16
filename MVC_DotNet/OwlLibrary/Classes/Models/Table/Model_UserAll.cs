using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Table
{
    public class Model_UserAll : Model_Table<Model_User>
    {
        public Model_UserAll()
        {
            Query = "SELECT * FROM users";
            Rows = new List<Model_User>();
            //ColumnsNames = new List<string> { "id", "role_id", "name", "pwd", "email" };
        }
    }
}

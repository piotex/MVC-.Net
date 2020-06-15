using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Table
{
    public class Model_UserTable : Model_Table<Model_User>
    {
        public Model_UserTable()
        {
            TableName = "users";
            Rows = new List<Model_User>();
            ColumnsNames = new List<string> { "id", "name", "pwd", "email" };
        }
    }
}

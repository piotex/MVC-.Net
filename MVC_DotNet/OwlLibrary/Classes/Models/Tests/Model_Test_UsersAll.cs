using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using System.Collections.Generic;

namespace OwlLibrary.Classes.Models.Tests
{
    public class Model_Test_UsersAll : Model_Table<Model_User>
    {
        public Model_Test_UsersAll()
        {
            Query = "SELECT * FROM test_users ORDER BY id ASC LIMIT 5";
            Rows = new List<Model_User>();
            //ColumnsNames = new List<string> { "id", "role_id", "name", "pwd", "email" };
        }
    }
}

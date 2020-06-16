using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query
{
    public class Model_Select_Roles : Model_Query<Model_Role>
    {
        public Model_Select_Roles()
        {
            Rows = new List<Model_Role>();
        }
        public override string get_Query()
        {
            return "SELECT * FROM user_role";
        }
    }
}
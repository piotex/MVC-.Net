using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query
{
    public class Model_Select_AllUsers : Model_Select<Model_User>
    {
        public Model_Select_AllUsers()
        {
            Query = "SELECT * FROM users";
        }
    }
}

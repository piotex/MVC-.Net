using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query
{
    public class Model_Insert_User : Model_Query<Model_User>
    {
        public Model_Insert_User()
        {
            //todo weryfikacja czy rekordy sa ok - wywalenie sql'a i innych atakow
            Rows = new List<Model_User>();
        }
        public override string get_Query()
        {
            return string.Format("INSERT into users(role_id, name, pwd, email) values({0}, '{1}','{2}','{3}');", Rows[0].role_id, Rows[0].name, Rows[0].pwd, Rows[0].email);
        }
    }
}
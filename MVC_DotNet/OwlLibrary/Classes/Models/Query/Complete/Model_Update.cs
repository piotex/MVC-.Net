using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query.Complete
{
    public class Model_Update<T_Record> : Model_Query<T_Record> where T_Record : Model_TableRecord
    {
        public Model_Update()
        {
            Rows = new List<T_Record>();
        }

        public override string get_Query()
        {
            List<List<string>> parameters = new List<List<string>>();
            get_Params(ref parameters);

            var objToDel = Rows[0];
            string query = "UPDATE  " + objToDel.table_name + " SET ";
            add_parameterToQuery(Enums.Enum_Action.Update,ref query, ref parameters);
            query += " WHERE role_id = 99";
            return query;
        }
    }
}
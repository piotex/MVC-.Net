using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query.Complete
{
    public class Model_Select<T_Record> : Model_Query<T_Record> where T_Record : Model_TableRecord, new()
    {
        public override string get_Query()
        {
            List<List<string>> values_ToSelect = new List<List<string>>();
            List<List<string>> records_ToChange = new List<List<string>>();
            get_SetValues(ref values_ToSelect);
            get_WhereRecords(ref records_ToChange);

            //  UPDATE test_users SET pwd = 'changed_pwd_xxxxxxxxxxxx', email = 'changed_email_addres@gmail.com'  WHERE role_id = 99

            string query = "SELECT ";
            query += values_ToSelect[0][1];
            for (int i = 1; i < values_ToSelect.Count; i++)
            {
                query += ", " + values_ToSelect[i][1];
            }
            query += " FROM ";
            query += Record_ToChange.table_name;
            if (records_ToChange.Count > 0)
            {
                query += " WHERE ";
                add_parameterToQuery(Enums.Enum_ParameterType.Where, ref query, ref records_ToChange);
            }

            return query;
        }
    }
}
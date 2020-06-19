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
            List<List<string>> records_ToChange = new List<List<string>>();
            get_WhereRecords(ref records_ToChange);

            //  UPDATE test_users SET pwd = 'changed_pwd_xxxxxxxxxxxx', email = 'changed_email_addres@gmail.com'  WHERE role_id = 99
            
            string query = "SELECT ";
            var properties = Constrain_Object.GetType().GetProperties();
            query += properties[0].Name;
            foreach (var propertie in properties)
            {
                if (propertie.Name != "table_name")
                {
                    query += ", " + propertie.Name;
                }
            }
            query += " FROM ";
            query += Constrain_Object.table_name;
            if (records_ToChange.Count > 0)
            {
                query += " WHERE ";
                add_parameterToQuery(Enums.Enum_ParameterType.Where, ref query, ref records_ToChange);
            }

            return query;
        }
    }
}
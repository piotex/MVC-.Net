using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query.Complete
{
    public class Model_Insert<T_Record> : Model_Query<T_Record> where T_Record : Model_TableRecord, new()
    {
        public override string get_Query()
        {
            List<List<string>> values_ToSet = new List<List<string>>();
            get_SetValues(ref values_ToSet);

            //INSERT into   test_users ( role_id, name, pwd, email) values (3, 'test_Adam', 'insert_pwd', 'insert_email@gmail.com');

            string query = "INSERT into   " + Record_ToChange.table_name + " ( ";
            query += values_ToSet[0][1];
            for (int i = 1; i < values_ToSet.Count; i++)
            {
                query += ", " + values_ToSet[i][1];
            }
            query += ") values (";
            query += values_ToSet[0][2];
            for (int i = 1; i < values_ToSet.Count; i++)
            {
                query += ", " + values_ToSet[i][2];
            }
            query += ");";
            return query;
        }
    }
}
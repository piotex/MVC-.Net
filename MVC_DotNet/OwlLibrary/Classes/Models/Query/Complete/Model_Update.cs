using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query.Complete
{
    public class Model_Update<T_Record> : Model_Query<T_Record> where T_Record : Model_TableRecord, new()
    {
        public override string get_Query()
        {
            List<List<string>> values_ToChange = new List<List<string>>();
            List<List<string>> records_ToChange = new List<List<string>>();
            get_SetValues(ref values_ToChange); 
            get_WhereRecords(ref records_ToChange);

            string query = "UPDATE  " + Record_ToChange.table_name + " SET ";
            add_parameterToQuery(Enums.Enum_ParameterType.Set, ref query, ref values_ToChange);
            query += " WHERE ";
            add_parameterToQuery(Enums.Enum_ParameterType.Where, ref query, ref records_ToChange);
            return query;
        }
    }
}
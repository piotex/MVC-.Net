using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query.Complete
{
    public class Model_Delete<T_Record> : Model_Query<T_Record> where T_Record : Model_TableRecord, new()
    {
        public override string get_Query()
        {
            List<List<string>> records_ToChange = new List<List<string>>();
            get_WhereRecords(ref records_ToChange);
            string query = "DELETE from "+ Record_ToChange.table_name + " WHERE ";
            add_parameterToQuery(Enums.Enum_ParameterType.Where, ref query, ref records_ToChange);
            return query;
        }
    }
}
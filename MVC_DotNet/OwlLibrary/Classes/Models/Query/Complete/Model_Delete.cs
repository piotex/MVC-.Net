﻿using OwlLibrary.Classes.Models.Basic;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Query.Complete
{
    public class Model_Delete<T_Record> : Model_Query<T_Record> where T_Record : Model_TableRecord
    {
        public Model_Delete()
        {
            Rows = new List<T_Record>();
        }
        
        public override string get_Query()
        {
            List<List<string>> parameters = new List<List<string>>();
            get_Params(ref parameters);

            var objToDel = Rows[0];
            string query = "DELETE from "+ objToDel.table_name + " WHERE ";
            add_parameterToQuery(Enums.Enum_Action.Delete,ref query, ref parameters);
            return query;
        }
    }
}
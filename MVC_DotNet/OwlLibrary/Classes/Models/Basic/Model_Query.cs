using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Basic
{
    public abstract class Model_Query<T_Record> where T_Record : Model_TableRecord, new()                           //todo zrobić z tego interfejs i wymuszac implementacje w klasach dziedziczacych
    {
        public Model_Query()
        {
            Rows = new List<T_Record>();
            Record_ToChange = new T_Record();
        }

        public abstract string get_Query();
        public T_Record Record_ToChange { get; set; }
        public List<T_Record> Rows { get; set; }




        //  | type | column_name | row_val |
        private int sth(ref T_Record objToDel, ref List<List<string>> parameters)
        {
            var properties = objToDel.GetType().GetProperties();

            foreach (var propertie in properties)
            {
                switch (Type.GetTypeCode(propertie.PropertyType))
                {
                    case TypeCode.Int32:
                        {
                            if (null != propertie.GetValue(objToDel) && (Int32)propertie.GetValue(objToDel) != 0)     //tu mogą byc bledy przy usuwaniu np produktu o ilosci 0
                            {
                                parameters.Add(new List<string>() { "int", propertie.Name, propertie.GetValue(objToDel).ToString() });
                            }
                            break;
                        }
                    case TypeCode.String:
                        {
                            if (null != propertie.GetValue(objToDel) && propertie.GetValue(objToDel).ToString() != "" && "table_name" != propertie.Name)
                            {
                                parameters.Add(new List<string>() { "string", propertie.Name, "'"+propertie.GetValue(objToDel).ToString()+"'" });
                            }
                            break;
                        }
                    default:
                        throw new Exception("Not implemented Type!!!...");
                }
            }
            return 0;
        }
        protected int get_SetValues(ref List<List<string>> parameters)
        {
            var tRecord = Rows[0];
            return sth(ref tRecord, ref parameters);
        }
        protected int get_WhereRecords(ref List<List<string>> parameters)
        {
            var objToDel = Record_ToChange;
            return sth(ref objToDel, ref parameters);
        }
        protected int add_parameterToQuery(Enum_ParameterType parameterType, ref string query, ref List<List<string>> parameters)
        {
            string separator = "xx0;";
            switch (parameterType)
            {
                case Enum_ParameterType.Where:
                    separator = " AND ";
                    break;
                case Enum_ParameterType.Set:
                    separator = " , ";
                    break;
                default:
                    throw new System.Exception("Not implemented actionType!!!");
            }
            if (parameters.Count > 0)
            {
                bool first = true;
                foreach (var param in parameters)
                {
                    if (!first)
                    {
                        query += separator;
                    }
                    if (first)
                    {
                        first = false;
                    }
                    query += param[1] + " = " + param[2] + " ";
                }
            }
            else
            {
                throw new Exception("Attempting to delete an undefined object....");
            }
            return 0;
        }


    }
}

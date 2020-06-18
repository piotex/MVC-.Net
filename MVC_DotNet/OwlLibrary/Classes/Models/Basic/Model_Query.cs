using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.Models.Basic
{
    public abstract class Model_Query<T_Record> where T_Record : Model_TableRecord                            //todo zrobić z tego interfejs i wymuszac implementacje w klasach dziedziczacych
    {
        public abstract string get_Query();
        public List<T_Record> Rows { get; set; }
        protected int get_Params(ref List<List<string>> parameters)
        {
            var objToDel = Rows[0];

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
                                parameters.Add(new List<string>() { "string", propertie.Name, propertie.GetValue(objToDel).ToString() });
                            }
                            break;
                        }
                    default:
                        throw new Exception("Not implemented Type!!!...");
                }
            }

            return 1;
        }
        protected int add_parameterToQuery(Enum_Action actionType, ref string query, ref List<List<string>> parameters)
        {
            string separator = "xx0;";
            switch (actionType)
            {
                case Enum_Action.Select:
                    throw new System.Exception("Not implemented actionType!!!");
                    break;
                case Enum_Action.Insert:
                    throw new System.Exception("Not implemented actionType!!!");
                    break;
                case Enum_Action.Delete:
                    separator = " AND ";
                    break;
                case Enum_Action.Update:
                    separator = " , ";
                    break;
                default:
                    throw new System.Exception("Not implemented actionType!!!");
                    break;
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
                    switch (param[0])
                    {
                        case "int":
                            {
                                query += param[1] + " = " + param[2] + " ";
                                break;
                            }
                        case "string":
                            {
                                query += param[1] + " = '" + param[2] + "' ";
                                break;
                            }
                        default:
                            throw new Exception("Not implemented Type!!!...");
                    }
                }
            }
            else
            {
                throw new Exception("Attempting to delete an undefined object....");
            }
            return 1;
        }



    }
}

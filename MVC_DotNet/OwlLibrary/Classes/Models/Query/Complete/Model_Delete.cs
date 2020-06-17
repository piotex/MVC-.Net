using OwlLibrary.Classes.Models.Basic;
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
                            if (null != propertie.GetValue(objToDel) && propertie.GetValue(objToDel).ToString() != "" &&  "table_name" != propertie.Name)
                            {
                                parameters.Add(new List<string>() { "string", propertie.Name, propertie.GetValue(objToDel).ToString() });
                            }
                            break;
                        }
                    default:
                        throw new Exception("Not implemented Type!!!...");
                }
            }
            string query = "DELETE from "+ objToDel.table_name + " WHERE ";
            if (parameters.Count > 0)
            {
                bool first = true;
                foreach (var param in parameters)
                {
                    if (!first)
                    {
                        query += " AND ";
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
            return query;
        }
    }
}
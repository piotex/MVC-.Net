using LionLibrary.Classes.Models;
using LionLibrary.Factory;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace LionLibrary.Classes.SetData
{
    public class SetObj_PostgreSQL<T_Model> where T_Model : Model_Table, new()
    {
        protected int sth(ref T_Model objToDel, ref List<List<string>> parameters)
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
                                parameters.Add(new List<string>() { "string", propertie.Name, "'" + propertie.GetValue(objToDel).ToString() + "'" });
                            }
                            break;
                        }
                    case TypeCode.Double:
                        {
                            if (null != propertie.GetValue(objToDel) && (Double)propertie.GetValue(objToDel) != 0)
                            {
                                parameters.Add(new List<string>() { "string", propertie.Name,  propertie.GetValue(objToDel).ToString().Replace(',','.')  });
                            }
                            break;
                        }
                    default:
                        throw new Exception("Not implemented Type!!!...");
                }
            }
            return 0;
        }

        private string get_Query(ref T_Model record)
        {
            List<List<string>> values_ToSet = new List<List<string>>();
            sth(ref record,ref values_ToSet);

            //INSERT into   test_users ( role_id, name, pwd, email) values (3, 'test_Adam', 'insert_pwd', 'insert_email@gmail.com');

            string query = "INSERT into   " + record.GetTableName() + " ( ";
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
        public int SetObj(ref T_Model record, string pathTo_ConnectionString)
        {
            try
            {
                using (NpgsqlConnection connecion = Factory_Connection<NpgsqlConnection>.GetConnection(pathTo_ConnectionString) as NpgsqlConnection)
                {
                    connecion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(get_Query(ref record), connecion);
                    cmd.ExecuteNonQuery();
                    connecion.Close();
                }
            }
            catch (Exception msg)
            {
                throw msg;
            }
            return 0;
        }
    }
}

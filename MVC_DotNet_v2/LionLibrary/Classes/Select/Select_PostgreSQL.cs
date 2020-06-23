using LionLibrary.Classes.Models;
using LionLibrary.Factory;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace LionLibrary.Classes.Select
{
    public class Select_PostgreSQL<T_Model> where T_Model: Model_Table, new()
    {
        public List<T_Model> Select(string pathTo_ConnectionString, string request)
        {
            List<T_Model> records = new List<T_Model>();
            try
            {
                using (NpgsqlConnection connecion = Factory_Connection<NpgsqlConnection>.GetConnection(pathTo_ConnectionString) as NpgsqlConnection)
                {
                    connecion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(request, connecion);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        T_Model record = new T_Model();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            var properties = record.GetType().GetProperties();
                            foreach (var propertie in properties)
                            {
                                if (propertie.Name == dr.GetName(i) && propertie.Name != "TableName")
                                {
                                    string cellData = dr[i].ToString();
                                    switch (Type.GetTypeCode(propertie.PropertyType))
                                    {
                                        case TypeCode.Int32:
                                            {
                                                propertie.SetValue(record, int.Parse(cellData));
                                                break;
                                            }
                                        case TypeCode.Double:
                                            {
                                                propertie.SetValue(record, Double.Parse(cellData));
                                                break;
                                            }
                                        case TypeCode.String:
                                            {
                                                propertie.SetValue(record, cellData.ToString());
                                                break;
                                            }
                                        default:
                                            throw new Exception("Not implemented Type!!!...");
                                    }
                                    break;
                                }
                            }
                        }
                        records.Add(record);
                    }
                    connecion.Close();
                }
            }
            catch (Exception msg)
            {
                throw msg;
            }
            return records;
        }




    }
}

using Npgsql;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Enums;
using OwlLibrary.Factory;
using OwlLibrary.Interfaces;
using System;

namespace OwlLibrary.Classes.GetData
{
    public class PostgreSQL_Select<T_Record> : Interface_Action<T_Record>, Interface_Request<T_Record> where T_Record : Model_TableRecord , new() 
    {
        public int DoAction(ref Model_Query<T_Record> tableModel)
        {
            try
            {
                using (NpgsqlConnection connecion = ConnectionFactory.makeConnection<NpgsqlConnection>(Enum_Db.PostgreeSQL) as NpgsqlConnection)
                {
                    connecion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(tableModel.get_Query(), connecion);
                    tableModel.Rows = new System.Collections.Generic.List<T_Record>();
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        T_Record record = new T_Record();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            var properties = record.GetType().GetProperties();
                            foreach (var propertie in properties)
                            {
                                if (propertie.Name == dr.GetName(i))
                                {
                                    string cellData = dr[i].ToString();
                                    switch (Type.GetTypeCode(propertie.PropertyType))
                                    {
                                        case TypeCode.Int32:
                                            {
                                                propertie.SetValue(record, Int32.Parse(cellData));
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
                        tableModel.Rows.Add(record);
                    }
                    connecion.Close();
                }
            }
            catch (Exception msg)
            {
                throw msg;
            }
            return 0;
        }

        public int MakeRequest(string request, ref Model_Query<T_Record> tableModel)
        {
            try
            {
                using (NpgsqlConnection connecion = ConnectionFactory.makeConnection<NpgsqlConnection>(Enum_Db.PostgreeSQL))
                {
                    connecion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(request, connecion);
                    tableModel.Rows = new System.Collections.Generic.List<T_Record>();
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        T_Record record = new T_Record();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            var properties = record.GetType().GetProperties();
                            foreach (var propertie in properties)
                            {
                                if (propertie.Name == dr.GetName(i))
                                {
                                    string cellData = dr[i].ToString();
                                    switch (Type.GetTypeCode(propertie.PropertyType))
                                    {
                                        case TypeCode.Int32:
                                            {
                                                propertie.SetValue(record, int.Parse(cellData));
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
                        tableModel.Rows.Add(record);
                    }
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

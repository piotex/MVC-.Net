using Npgsql;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Classes.Models.Table;
using OwlLibrary.Enums;
using OwlLibrary.Factory;
using OwlLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.GetData
{
    public class PostgreSQL_select<T_Record> : Interface_Action<T_Record> where T_Record :  new()
    {
        public int DoAction(ref Model_Table<T_Record> tableModel)
        {
            try
            {
                using (NpgsqlConnection connecion = ConnectionFactory.makeConnection<NpgsqlConnection>(Enum_Db.PostgreeSQL) as NpgsqlConnection)
                {
                    connecion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(tableModel.Query, connecion);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        T_Record record = new T_Record();
                        int numberOfRows = record.GetType().GetProperties().Length;
                        for (int i = 0; i < numberOfRows; i++)
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

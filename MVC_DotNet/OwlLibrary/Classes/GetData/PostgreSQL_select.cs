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
    public class PostgreSQL_select<T> : Interface_Action<T> where T : Model_User, new()
    {
        public int DoAction(ref Model_Table<T> tableModel)
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
                        T record = new T();
                        for (int i = 0; i < tableModel.ColumnsNames.Count; i++)
                        {
                            foreach (var item in record.GetType().GetProperties())
                            {
                                if (item.Name == dr.GetName(i))
                                {
                                    string cellData = dr[i].ToString();
                                    switch (Type.GetTypeCode(item.PropertyType))
                                    {
                                        case TypeCode.Int32:
                                            {
                                                item.SetValue(record, Int32.Parse(cellData));
                                                break;
                                            }
                                        case TypeCode.String:
                                            {
                                                item.SetValue(record, cellData.ToString());
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

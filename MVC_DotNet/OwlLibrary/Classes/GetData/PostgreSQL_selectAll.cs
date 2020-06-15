using Npgsql;
using OwlLibrary.Classes.Models.Table;
using OwlLibrary.Enums;
using OwlLibrary.Factory;
using OwlLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.GetData
{
    public class PostgreSQL_selectAll<T> : Interface_Action<T> where T : Model_User, new()
    {
        public int DoAction(ref Model_Table<T> tableModel)
        {
            try
            {
                string sql = "SELECT * FROM users";

                NpgsqlConnection con = ConnectionFactory.makeConnection<NpgsqlConnection>(Enum_Db.PostgreeSQL) as NpgsqlConnection;
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    T record = new T();
                    for (int i = 0; i < tableModel.ColumnsNames.Count; i++)
                    {
                        foreach (var item in record.GetType().GetProperties())
                        {
                            var aaaaaa = dr.GetName(i);
                            if (item.Name == dr.GetName(i))
                            {
                                var aalallala = dr[i];
                                string recordXXXS = dr[i].ToString();
                                item.SetValue(record, recordXXXS);
                                break;
                            }
                        }
                    }
                    tableModel.Rows.Add(record);
                }
                con.Close();
            }
            catch (Exception msg)
            {
                throw msg;
            }
            return 1;
        }
    }
}

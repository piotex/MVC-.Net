using Npgsql;
using OwlLibrary.Enums;
using OwlLibrary.Factory;
using OwlLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Classes.GetData
{
    public class PostgreSQL_selectAll : Interface_Action
    {
        public int DoAction()
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
                    string aaaaaaaaa = dr[0].ToString();
                    string aaaaaaaaa4 = dr[1].ToString();
                    string aaaaaaaaa5 = dr[2].ToString();
                }
                con.Close();
            }
            catch (Exception msg)
            {
                throw;
            }
            return 1;
        }
    }
}

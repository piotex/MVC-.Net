using Npgsql;
using OwlLibrary.Classes.Connection;
using OwlLibrary.Enums;
using OwlLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace OwlLibrary.Factory
{
    public static class ConnectionFactory
    {
        private static Dictionary<Enum_Db, Interface_DbConnection> _dic = new Dictionary<Enum_Db, Interface_DbConnection>
        {
            {Enum_Db.PostgreeSQL, new  PostgreSQL_Connection()}
        };
        public static DbConnection makeConnection(Enum_Db dbType)
        {
            DbConnection conn = null;
             _dic[dbType].Connect(ref conn);
            return conn;

            try
            {
                string sql = "SELECT * FROM users";
                
                NpgsqlConnection con = conn as NpgsqlConnection;
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
        }
    }
}

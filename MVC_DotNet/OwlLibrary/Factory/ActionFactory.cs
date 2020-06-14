using OwlLibrary.Enums;
using OwlLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwlLibrary.Factory
{
    public static class ActionFactory
    {
        private static Dictionary<Enum_Action, Interface_Action> _dic = new Dictionary<Enum_Action, Interface_Action>
        {
            {Enum_Action.SelectAll, new PostgreSQL_selectAll() }
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

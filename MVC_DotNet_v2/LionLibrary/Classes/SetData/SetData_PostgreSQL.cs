using LionLibrary.Factory;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace LionLibrary.Classes.SetData
{
    public class SetData_PostgreSQL
    {
        public int SetData(string pathTo_ConnectionString, string request)
        {
            try
            {
                using (NpgsqlConnection connecion = Factory_Connection<NpgsqlConnection>.GetConnection(pathTo_ConnectionString) as NpgsqlConnection)
                {
                    connecion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(request, connecion);
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

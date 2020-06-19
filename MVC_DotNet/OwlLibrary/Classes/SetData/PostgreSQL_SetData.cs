using Npgsql;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Enums;
using OwlLibrary.Factory;
using OwlLibrary.Interfaces;
using System;

namespace OwlLibrary.Classes.SetData
{
    public class PostgreSQL_SetData<T_Record> : Interface_Action<T_Record>, Interface_Request<T_Record> where T_Record : Model_TableRecord, new()
    {
        public int DoAction(ref Model_Query<T_Record> tableModel)
        {
            try
            {
                using (NpgsqlConnection connecion = ConnectionFactory.makeConnection<NpgsqlConnection>(Enum_Db.PostgreeSQL) as NpgsqlConnection)
                {
                    connecion.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(tableModel.get_Query(), connecion);
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

        public int MakeRequest(string request, ref Model_Query<T_Record> tableModel)
        {
            try
            {
                using (NpgsqlConnection connecion = ConnectionFactory.makeConnection<NpgsqlConnection>(Enum_Db.PostgreeSQL) as NpgsqlConnection)
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

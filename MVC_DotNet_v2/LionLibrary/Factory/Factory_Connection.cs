using LionLibrary.Classes.Connection;
using LionLibrary.Enums;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace LionLibrary.Factory
{
    public static class Factory_Connection<T_DbConnection> where T_DbConnection : DbConnection, new()
    {
        public static DbConnection GetConnection(string connectionString)
        {
            if (typeof(T_DbConnection) == typeof(NpgsqlConnection))
            {
                return new Connection_PostgreSQL(connectionString).GetConnection();
            }

            throw new NotImplementedException();
        }
    }
    
}

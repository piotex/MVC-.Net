using Npgsql;
using OwlLibrary.Interfaces;
using System;
using System.Data.Common;

namespace OwlLibrary.Classes.Connection
{
    public class PostgreSQL_Connection : Interface_DbConnection
    {
        private string _connectionString;
        public PostgreSQL_Connection()
        {
            string server = "127.0.0.1";
            string port = "5432";
            string id = "postgres";
            string pwd = "1234";
            string database = "MVC_DotNet_DB";

            _connectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", server, port, id, pwd, database);
        }
        public int Connect<T>(ref T connection) where T : DbConnection
        {
            connection = (T)((new NpgsqlConnection(_connectionString) ) as DbConnection);
            return 1;
        }
    }
}

using Npgsql;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Interfaces;
using System;
using System.Data.Common;
using System.IO;
using System.Xml.Serialization;

namespace OwlLibrary.Classes.Connection
{
    public class PostgreSQL_Connection : Interface_DbConnection
    {
        private string _connectionString;
        public PostgreSQL_Connection()
        {
            //string server = "127.0.0.1";
            //string port = "5432";
            //string id = "postgres";
            //string pwd = "1234";
            //string database = "MVC_DotNet_DB";
            //_connectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", server, port, id, pwd, database);

            string path = @"C:\Users\pkubo\OneDrive\Desktop\MVC_DotNet\MVC_DotNet\OwlLibrary\db_config.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Model_Connection));
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                Model_Connection result = (Model_Connection)serializer.Deserialize(fileStream);
                _connectionString = result.ConnectionString;
            }
        }
        public int Connect<T>(ref T connection) where T : DbConnection
        {
            connection = (T)((new NpgsqlConnection(_connectionString) ) as DbConnection);
            return 1;
        }
    }
}

using LionLibrary.Classes.Connection.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LionLibrary.Classes.Connection 
{ 
    public class Connection_PostgreSQL
    {
        public string _ConnectionString;

        public Connection_PostgreSQL()      //to do - przerobic to na ogolne - dodatkowa opcja z enuma wygierać db do ktorego ma zwrocic połączenie
        {
            //string server = "127.0.0.1";
            //string port = "5432";
            //string id = "postgres";
            //string pwd = "1234";
            //string database = "MVC_DotNet_DB";
            //_ConnectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", server, port, id, pwd, database);
        }
        public Connection_PostgreSQL(string path)
        {
            if (path.ToLower().Contains(".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Model_Connection));
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    Model_Connection result = (Model_Connection)serializer.Deserialize(fileStream);
                    _ConnectionString = result.ConnectionString;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public NpgsqlConnection GetConnection() 
        {
            return new NpgsqlConnection(_ConnectionString);
        }
    }
}

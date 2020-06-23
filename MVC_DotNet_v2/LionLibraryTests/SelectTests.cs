using LionLibrary.Classes.Models;
using LionLibrary.Classes.Select;
using LionLibrary.Factory;
using Npgsql;
using NUnit.Framework;
using System.Data.Common;

namespace LionLibraryTests
{
    class TestModel : Model_Table
    {
        public int role_id { get; set; }
        public string name { get; set; }
        public string pwd { get; set; }
        public string email { get; set; }

        public override string GetTableName()
        {
            return "users";
        }
    }

    public class SelectTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConnectionTest_PostgreSQL()
        {
            string connStr = @"C:\Users\pkubo\OneDrive\Desktop\MVC_DotNet\MVC_DotNet_v2\LionLibrary\db_config.xml";
            string req = "SELECT * FROM users";
            var h = new Select_PostgreSQL<TestModel>().Select(connStr,req);
        }
    }
}
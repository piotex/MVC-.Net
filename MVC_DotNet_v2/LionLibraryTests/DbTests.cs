using LionLibrary.Classes.Models;
using LionLibrary.Classes.Select;
using LionLibrary.Classes.SetData;
using LionLibrary.Factory;
using Npgsql;
using NUnit.Framework;
using System.Data.Common;

namespace LionLibraryTests
{
    class TestModel : Model_Table
    {
        public int id { get; set; }
        public int role_id { get; set; }
        public string name { get; set; }
        public string pwd { get; set; }
        public string email { get; set; }

        public override string GetTableName()
        {
            return "users";
        }
    }

    public class DbTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Selest_Test()
        {
            string connStr = @"C:\Users\pkubo\OneDrive\Desktop\MVC_DotNet\MVC_DotNet_v2\LionLibrary\db_config.xml";
            string req = "SELECT * FROM users";
            var h = new Select_PostgreSQL<TestModel>().Select(connStr, req);
        }
        [Test]
        public void Update_Test()
        {
            string connStr = @"C:\Users\pkubo\OneDrive\Desktop\MVC_DotNet\MVC_DotNet_v2\LionLibrary\db_config.xml";
            string query = "UPDATE users SET pwd = 'changed_pwd' WHERE id = 12;";
            new SetData_PostgreSQL().SetData(connStr, query);
        }
        [Test]
        public void Delete_Test()
        {
            string connStr = @"C:\Users\pkubo\OneDrive\Desktop\MVC_DotNet\MVC_DotNet_v2\LionLibrary\db_config.xml";
            string query = "DELETE FROM users WHERE id = 12;";
            new SetData_PostgreSQL().SetData(connStr, query);
        }
        [Test]
        public void Insert_Test()
        {
            string connStr = @"C:\Users\pkubo\OneDrive\Desktop\MVC_DotNet\MVC_DotNet_v2\LionLibrary\db_config.xml";
            TestModel t = new TestModel()
            {
                email = "ins_em@gmail.com",
                name = "ins_nam",
                pwd = "ins_pwd",
                role_id = 99
            };
            new SetObj_PostgreSQL<TestModel>().SetObj(ref t,connStr);
        }


    }
}